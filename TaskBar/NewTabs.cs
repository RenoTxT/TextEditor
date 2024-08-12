using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.TaskBar
{
    public class NewTabs : Taskbar
    {
        private TextBox _textBox;

        // Constructor to initialize the TextBox reference
        public NewTabs(TextBox textBox)
        {
            _textBox = textBox;
        }

        public override void FuntionTaskbar()
        {
            title = "Untitled";
            File.Create(title);
            string filePath = Path.Combine(Path.GetTempPath(), $"{title}.txt");

            // Create a new file (or tab) and set default content
            using (FileStream fs = File.Create(filePath))
            {
                // Optionally write default content or metadata to the file if needed
            }

            // Set default font settings
            _textBox.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular); // Default font family, size, and style
            _textBox.ForeColor = Color.Black; // Default font color
            _textBox.BackColor = Color.White; // Default background color
        }
    }
}
