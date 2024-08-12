using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TextEditor.FileManager;

namespace TextEditor.TaskBar
{
    public class Open : Taskbar
    {
        public string Content { get; set; }
        public string FilePath { get; set; }
        public Font ChosenFont { get; set; }
        public Font TextFont { get; set; }
        public Color FontColoring { get; set; }
        public Color BackgroundColoring { get; set; }
        public string OpenFilePath { get; private set; }

        private TextBox _textBox;

        public Open(TextBox textBox)
        {
            _textBox = textBox;
        }

        public override void FuntionTaskbar()
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFilePath = openFileDialog.FileName;
                string extension = Path.GetExtension(OpenFilePath).ToLower();
                title = Path.GetFileName(OpenFilePath);
                if (extension == ".txt")
                {
                    content = File.ReadAllText(OpenFilePath);
                    _textBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    _textBox.ForeColor = Color.Black; 
                    _textBox.BackColor = Color.White; 
                }
                else if(extension == ".xml")
                {
                    var xmlFormat = new XMLFormat(FilePath, title, content, ChosenFont, FontColoring, BackgroundColoring);

                    xmlFormat.LoadXML(OpenFilePath, _textBox);

                    content = _textBox.Text;
                }
            }
        }
    }
}
