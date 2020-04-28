using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace DLLLoader
{
    public class Updater
    {
        static public CoreForm CoreForm;
        /// <summary>
        /// Config class, must compile it!
        /// </summary>
        /// 
        public class Config
        {
            /// <summary>
            /// Path Directory
            /// </summary>
            public static string Path { get; set; }
            /// <summary>
            /// File with hashes, save location .json
            /// </summary>
            public static string Md5File { get; set; }
            /// <summary>
            /// Bool var, create or not hashes file
            /// </summary>
            public static bool CreateMd5File { get; set; }
            /// <summary>
            /// Path of lzma.exe compressor
            /// </summary>
            public static string LzmaCompressor { get; set; }
            /// <summary>
            /// Path compressed files
            /// </summary>
            public static string CompressedDir { get; set; }
            /// <summary>
            /// Bool, compress or not files
            /// </summary>
            public static bool Compress { get; set; }
        }

         protected string GetMd5HashFromFile(string fileName)
        {
            try
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    SHA256Managed sha = new SHA256Managed();
                    byte[] checksum = sha.ComputeHash(stream);
                    return BitConverter.ToString(checksum).Replace("-", String.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        protected string[] FilesPath(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ConcurrentDictionary<string, string> Hashes = new ConcurrentDictionary<string, string>();
        public ConcurrentDictionary<string, string> ComputeHashes(string[] files,int chunkStart,int chunkEnd)
        {
            for (int j = chunkStart; j < chunkEnd; j++) //строго меньше chunkEnd
            {
                var hash = GetMd5HashFromFile(files[j]);
                Hashes.TryAdd(files[j].Replace(Config.Path + "\\", ""), hash);
                CoreForm.textBox1.AppendText("Создание хэшей: " + files[j].Replace(Config.Path, "") + Environment.NewLine);
            }
          return Hashes;
        }

        /// <summary>
        /// Create Recursive file hashes of a directory and save them into a json file or a local variable
        /// </summary>
      
        public string CreateHashes() // чанк и деление на количество ядер
        {
            if (Config.Path.ToString() != string.Empty)
            {    
                try
                {
                    var files = FilesPath(Config.Path.ToString());
                    var numThreads = Environment.ProcessorCount;
                    int LastFileComputed = files.Length;
                    if (files.Length < numThreads)  //файлов меньше ядер => каждый файл в свой поток
                    {
                        int filesarraychunk = 1;
                        int chunkEnd = 0;
                        Thread[] threads = new Thread[files.Length];
                        for (int i = 0; i < files.Length; ++i)
                        {
                            int chunkStart = chunkEnd;
                            chunkEnd = chunkStart + filesarraychunk;
                            int chunkEnd1 = chunkEnd;
                            threads[i] = new Thread(() => ComputeHashes(files, chunkStart, chunkEnd1));
                            threads[i].Start();
                        }
                        foreach (var thread in threads)
                        {
                            thread.Join();
                        }
                    }
                    else
                    {
                        int filesarraychunk = (files.Length / numThreads); //если больше => делим на куски
                        int chunkEnd = 0;
                        Thread[] threads = new Thread[numThreads];
                        for (int i = 0; i < numThreads; ++i)
                        {
                            int chunkStart = chunkEnd;
                            chunkEnd = chunkStart + filesarraychunk;
                            int chunkEnd1 = chunkEnd;
                            threads[i] = new Thread(() => ComputeHashes(files, chunkStart, chunkEnd1));
                            threads[i].Start();
                        }
                        foreach (var thread in threads)
                        {
                            thread.Join();
                        }
                    }
                    
                    if (Hashes.Count < files.Length) //если что-то осталось неподсчитанным 

                    {
                        LastFileComputed = Hashes.Count;
                        int filesarraychunk = 1;
                        int chunkEnd = LastFileComputed;
                        Thread[] threads = new Thread[files.Length-Hashes.Count];
                        for (int i = 0; i < files.Length - Hashes.Count; ++i)
                        {
                            int chunkStart = chunkEnd;
                            chunkEnd = chunkStart + filesarraychunk;
                            int chunkEnd1 = chunkEnd;
                            threads[i] = new Thread(() => ComputeHashes(files, chunkStart, chunkEnd1));
                            threads[i].Start();
                        }
                        foreach (var thread in threads)
                        {
                            thread.Join();
                        }
                        //   ComputeHashes(files, Hashes.Count, files.Length); //для последовательного пересчета
                    }
                    var json = JsonConvert.SerializeObject(Hashes);
                    if (Config.CreateMd5File == true)
                    {
                           if (Config.Md5File == string.Empty)
                               MessageBox.Show(
                                   "Can't write md5 to json file! Please set MD5File var in the Updater.Config", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                           else
                               using (StreamWriter sw = new StreamWriter(Config.Md5File))
                                   sw.Write(json);
                           if (Config.Compress != true) return json;
                           if (!Directory.Exists(Config.CompressedDir)) return json;
                           if (!File.Exists(Config.LzmaCompressor)) return json;
                        //---------------------------------------------------------------------------
                        //сжатие      
                        //---------------------------------------------------------------------------
                        if (files.Length < numThreads)  
                        {
                            int filesarraychunk = 1;
                            int chunkEnd = 0;
                            Thread[] threads = new Thread[files.Length];
                            for (int i = 0; i < files.Length; ++i)
                            {
                                int chunkStart = chunkEnd;
                                chunkEnd = chunkStart + filesarraychunk;
                                int chunkEnd1 = chunkEnd;
                                threads[i] = new Thread(() => CompressFile(files, chunkStart, chunkEnd1));
                                threads[i].Start();
                            }
                            foreach (var thread in threads)
                            {
                                thread.Join();
                            }
                        }
                        else
                        {
                            int filesarraychunk = (files.Length / numThreads); 
                            int chunkEnd = 0;
                            Thread[] threads = new Thread[numThreads];
                            for (int i = 0; i < numThreads; ++i)
                            {
                                int chunkStart = chunkEnd;
                                chunkEnd = chunkStart + filesarraychunk;
                                int chunkEnd1 = chunkEnd;
                                threads[i] = new Thread(() => CompressFile(files, chunkStart, chunkEnd1));
                                threads[i].Start();
                            }
                            foreach (var thread in threads)
                            {
                                thread.Join();
                            }
                        }
                        if (LastFileComputed != files.Length)
                        {
                            int filesarraychunk = 1;
                            int chunkEnd = LastFileComputed;
                            Thread[] threads = new Thread[files.Length - LastFileComputed];
                            for (int i = 0; i < files.Length - LastFileComputed; ++i)
                            {
                                int chunkStart = chunkEnd;
                                chunkEnd = chunkStart + filesarraychunk;
                                int chunkEnd1 = chunkEnd;
                                threads[i] = new Thread(() => CompressFile(files, chunkStart, chunkEnd1));
                                threads[i].Start();
                            }
                            foreach (var thread in threads)
                            {
                                thread.Join();
                            }
                        }
                        CoreForm.textBox1.AppendText("---------------------------------------------------------------" + Environment.NewLine);
                        return json;
                    }
                    return json;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Config.Path var not Set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }    
        }

        /// <summary>
        /// Compress Files Async
        /// </summary>

        protected void CompressFile(string[] files, int chunkStart, int chunkEnd)   
        {
            for (int j = chunkStart; j < chunkEnd; j++)
            {
                if (files[j].Contains(".lzma")) return;
                if (!(files[j].Contains("md5.json"))) // EXCLUDE !!!!!
                {
                    CoreForm.textBox1.AppendText("Сжатие файла: " + files[j].Replace(Config.Path, "") + Environment.NewLine); // Short Path                                                                                                   
                    var path = Config.CompressedDir + "\\" + files[j].Replace(Config.Path, "");
                    var dir = path;
                    var index = dir.LastIndexOf("\\", StringComparison.Ordinal);
                    if (index > 0)
                        dir = dir.Substring(0, index);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    Compression(files[j]);
                }
            }
        }

        #pragma warning disable CS1998
        /// <summary>               
        /// Compression Framework                
        /// </summary>

        protected void Compression(string file) 
        {
            using (Process process = Process.Start(new ProcessStartInfo()
            {
                FileName = Config.LzmaCompressor,
                Arguments = "e " + AddCommasIfRequired(file) + " " + AddCommasIfRequired(Config.CompressedDir + "\\" + file.Replace(Config.Path, "")) + ".lzma -d21",
                UseShellExecute = false,
                RedirectStandardOutput = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }))

            {
                while (process != null && !process.HasExited)
                    Thread.Sleep(300);
            }
        }
        
        /// <summary>               
        /// Comma Path Checking              
        /// </summary>
 
        public string AddCommasIfRequired(string path) 
        {
            return (path.Contains(" ")) ? "\"" + path + "\"" : path;
        }
    }
}