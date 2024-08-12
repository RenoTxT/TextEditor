using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.TaskBar;
using System.IO;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using TextEditor.TaskBar.Edit;

namespace TextEditor
{
    public partial class TextEditor : Form
    {
        public string currentFilePath { get; set; }
        public bool saved { get; set; }
        public string ContentFileManager { get; set; }
        public Font font { get; set; }
        public Color currentFontColor { get; set; }
        public Color currentBackgroundColor { get; set; }
        public bool isFileSave { get; set; }

        public TextEditor()
        {
            InitializeComponent();
            this.Text = "Untitled";
            isFileSave = false;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taskbar exit = new Exit();
            exit.FuntionTaskbar();
            if (exit.exitTextEditor == true)
            {
                this.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taskbar about = new About();
            about.FuntionTaskbar();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileSave && !string.IsNullOrEmpty(currentFilePath))
            {
                Taskbar save = new Save
                {
                    Content = ContentFileManager,
                    Title = this.Text,
                    ChosenFont = textBox1.Font,
                    FontColoring = textBox1.ForeColor,
                    BackgroundColoring = textBox1.BackColor,
                    FilePath = currentFilePath
                };
                save.title = this.Text;
                save.content = textBox1.Text;
                ContentFileManager = save.content;
                save.FuntionTaskbar();
                isFileSave = true;
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs saveAsTaskbar = new SaveAs
            {
                Content = ContentFileManager,
                Title = this.Text,
                ChosenFont = textBox1.Font,
                FontColoring = textBox1.ForeColor,
                BackgroundColoring = textBox1.BackColor,
            };
            saveAsTaskbar.title = this.Text;
            saveAsTaskbar.content = textBox1.Text;
            saveAsTaskbar.FuntionTaskbar();
            this.Text = saveAsTaskbar.title;
            isFileSave = true;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontEdit fontEdit = new FontEdit(textBox1.Font);
            fontEdit.FuntionTaskbar();
            textBox1.Font = fontEdit.ChoosedFont;
        }

        private void opToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open openTask = new Open(textBox1);
            openTask.FuntionTaskbar();

            if (openTask.OpenFilePath != null)
            {
                currentFilePath = openTask.OpenFilePath;
                this.Text = Path.GetFileName(openTask.OpenFilePath);
                textBox1.Text  = openTask.content;
                ContentFileManager = openTask.content;
            }
            isFileSave = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taskbar newNote = new NewTabs(textBox1);
            newNote.FuntionTaskbar();
            textBox1.Text = newNote.content;
            ContentFileManager = newNote.content;
            this.Text = newNote.title;
            isFileSave = false;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fill with none
        }

        private void fontColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorFont = new ColorDialog())
            {
                colorFont.Color = currentFontColor;

                if (colorFont.ShowDialog() == DialogResult.OK)
                {
                    currentFontColor = colorFont.Color;
                }
                else
                {

                }
                textBox1.ForeColor = currentFontColor;
            }
        }

        private void bcakgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorBG = new ColorDialog())
            {
                colorBG.Color = currentBackgroundColor;

                if (colorBG.ShowDialog() == DialogResult.OK)
                {
                    currentBackgroundColor = colorBG.Color;
                }
                else
                {

                }
                textBox1.BackColor = currentBackgroundColor;
            }
        }
    }
}