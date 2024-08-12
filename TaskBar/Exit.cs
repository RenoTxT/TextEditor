using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.TaskBar
{
    public class Exit : Taskbar
    {
        public override void FuntionTaskbar()
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                exitTextEditor = true;
            }
            else
            {
                exitTextEditor= false;
            }
        }
    }
}
