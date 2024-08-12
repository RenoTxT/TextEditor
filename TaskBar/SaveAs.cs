using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using TextEditor.FileManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextEditor.TaskBar.Edit;

namespace TextEditor.TaskBar
{
    public class SaveAs : Taskbar
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public Font ChosenFont { get; set; }
        public Color FontColoring { get; set; }
        public Color BackgroundColoring { get; set; }

        public SaveAs()
        {
        }

        public override void FuntionTaskbar()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = title;
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();

                    if (extension == ".txt")
                    {
                        File.WriteAllText(saveFileDialog.FileName, content);
                        title = Path.GetFileName(saveFileDialog.FileName);
                    }
                    else if (extension == ".xml")
                    {
                        XMLFormat xmlFormat = new XMLFormat(saveFileDialog.FileName, Title, content, ChosenFont, FontColoring, BackgroundColoring);
                        xmlFormat.WriteToFile();
                        title = Path.GetFileName(saveFileDialog.FileName);
                    }
                }
            }
        }
    }
}
