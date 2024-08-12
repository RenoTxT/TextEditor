using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.TaskBar.Edit
{
    public class FontEdit : Taskbar
    {
        public Font ChoosedFont { get; private set; }

        public FontEdit(Font initialFont)
        {
            ChoosedFont = initialFont;
        }

        public override void FuntionTaskbar()
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = ChoosedFont;
                    
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    ChoosedFont = fontDialog.Font;
                }
                else
                {

                }
            }
        }

    }
}
