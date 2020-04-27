using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DLLLoader
{
    public class TextBoxStreamWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            try
            { 
            base.Write(value);
            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}