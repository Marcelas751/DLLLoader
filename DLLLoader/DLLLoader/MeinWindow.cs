using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;


namespace DLLLoader
{

    public partial class CoreForm : Form
    {
        #region Библиотеки
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру(int 13 вспомним....)
        const int
            WM_KEYDOWN = 0x100,       //Key down
            WM_KEYUP = 0x101;         //Key up

        private LowLevelKeyboardProc _proc = hookProc;

        private static IntPtr hhook = IntPtr.Zero;
        #endregion
        string[] argumentDLLLoader;
        private readonly SynchronizationContext synchronizationContext;
        //private DateTime previousTime = DateTime.Now;
        
        public CoreForm(string[] args)
        {
            Location = new Point(0, 0);
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            argumentDLLLoader = args;
            InitializeComponent();
            //Запуск хука
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
            synchronizationContext = SynchronizationContext.Current; //context from UI thread 
            DisplayU();
            Updater.CoreForm = this;
            CheckForIllegalCrossThreadCalls = false;
            
        }
        private void CoreForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(hhook); //Остановить хук
        }
        #region Функция хука
        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN || code >= 0 && wParam == (IntPtr)260)
            {
                int vkCode = Marshal.ReadInt32(lParam); //Получить код клавиши
                if (vkCode == 19) //Нажатие Pause
                {
                    Updater.Config.Freeze = !(Updater.Config.Freeze);
                    if (Updater.Config.Freeze == true)
                    {
                        MessageBox.Show("Завершение работы над текущими файлами и остановка. \nНажмите ОК чтобы продолжить.");
                        Updater.Config.Freeze = !(Updater.Config.Freeze);
                        
                    }
                }
            }
            return IntPtr.Zero;
        }
        #endregion
        // записывает ключ в реестр
        static public void SetKeyValue(string DirName, string name, string value)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(DirName);
            key.SetValue(name, value);
        }
        // восстановление ключа в реестре
        static public string GetKeyValue(string DirName, string name)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(DirName, true);
                return key.GetValue(name).ToString();
            }
            catch
            {
                return "00";
            }
        }

        private void DisplayU()
        {
            // Set UploadDir
            if (GetKeyValue(@"Software\TSG\TSG MOD Loader\", "UploadDir") != "00")
            {
                string uploadPath = GetKeyValue(@"Software\TSG\TSG MOD Loader\", "UploadDir");
                textBox2.Text = uploadPath;
            }
            else
            {
                textBox2.Text = @"D:\Temp\Upload";
                textBox1.AppendText("Error Set Upload Dir!" + Environment.NewLine);
            }
            // Set Compressed Dir
            if (GetKeyValue(@"Software\TSG\TSG MOD Loader\", "CompressDir") != "00")
            {
                string compressPath = GetKeyValue(@"Software\TSG\TSG MOD Loader\", "CompressDir");
                textBox3.Text = compressPath;
            }
            else
            {
                textBox3.Text = @"D:\Temp\Compressedfilestoupdate";
                textBox1.AppendText("Error Set Compressed Dir!" + Environment.NewLine);
            }
        }

        // Deleting Dirs
        private void processDirectory(string startLocation)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(startLocation))
                {
                    processDirectory(directory);

                    Directory.Delete(directory, true);
                    textBox1.AppendText("Очистка выходной директории: " + directory + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Start Compress
        private void Button2_Click(object sender, EventArgs e) // Compress
        {
            try
            {
                textBox1.Clear();
                listViewFiles.Items.Clear();
                button_changeModDir.Enabled = false;
                button_changeModDirCompress.Enabled = false;
                Compress.Enabled = false;
                MessageBox.Show("Для приостановки процесса нажмите Pause на клавиатуре.");
                textBox1.AppendText("Сжатие запущено: " + "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + Environment.NewLine);

                SetKeyValue(@"Software\TSG\TSG MOD Loader\", "UploadDir", textBox2.Text);
                SetKeyValue(@"Software\TSG\TSG MOD Loader\", "CompressDir", textBox3.Text);

                processDirectory(textBox3.Text);
                textBox1.AppendText("----------------------------------------------------------" + Environment.NewLine);
                Thread.Sleep(300);


                {
                    var up = new Updater();
                    Updater.Config.Path = textBox2.Text;  // Upload Dir
                    Updater.Config.Md5File = textBox3.Text + "\\md5.json";
                    Updater.Config.CreateMd5File = true; // Create the JSON File
                    Updater.Config.LzmaCompressor = AppDomain.CurrentDomain.BaseDirectory + @"Compressor\lzma.exe";
                    Updater.Config.CompressedDir = textBox3.Text; // Compressed Dir
                    Updater.Config.Compress = true;
                    up.CreateHashes(); // Make local files checksum
                }
                textBox1.AppendText("Сжатие ЗАВЕРШЕНО: " + "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]" + Environment.NewLine);
                textBox1.AppendText("----------------------------------------------------------" + Environment.NewLine);
                textBox1.AppendText("Готов к работе!" + Environment.NewLine);
                MessageBox.Show("Сжатие и подсчет хэшей завершено. \nГотов к работе!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_changeModDir.Enabled = true;
                button_changeModDirCompress.Enabled = true;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_changeModDir_Click(object sender, EventArgs e)
        {
            Compress.Enabled = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = textBox2.Text;
            fbd.Description = "Выберите путь к папке TSG MODs: ";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                textBox2.Text = fbd.SelectedPath;

                SetKeyValue(@"Software\TSG\TSG MOD Loader\", "UploadDir", sSelectedPath);
                //Application.Restart();
            }
        }
        
        private void button_changeModDirCompress_Click(object sender, EventArgs e)
        {
            Compress.Enabled = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = textBox3.Text;
            fbd.Description = "Выберите путь к папке Compressed TSG MODs: ";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = fbd.SelectedPath;
                textBox3.Text = fbd.SelectedPath;

                SetKeyValue(@"Software\TSG\TSG MOD Loader\", "CompressDir", sSelectedPath);
                //Application.Restart();
            }
        }
   
    }
}