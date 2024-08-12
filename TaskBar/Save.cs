using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using TextEditor.FileManager;

namespace TextEditor.TaskBar
{
    public class Save : Taskbar
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public Font ChosenFont { get; set; }
        public Font TextFont { get; set; }
        public Color FontColoring { get; set; }
        public Color BackgroundColoring { get; set; }

        public Save()
        {
        }

        public override void FuntionTaskbar()
        {
            string extension = Path.GetExtension(FilePath).ToLower();

            if (extension == ".txt")
            {
                File.WriteAllText(FilePath, content);
                title = Path.GetFileName(FilePath);
            }
            else if (extension == ".xml")
            {
                XMLFormat xmlFormat = new XMLFormat(FilePath, Title, content, ChosenFont, FontColoring, BackgroundColoring);
                xmlFormat.WriteToFile();
            }
        }
    }
}
