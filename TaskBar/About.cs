using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.TaskBar
{
    public class About : Taskbar
    {
        public override void FuntionTaskbar()
        {
            MessageBox.Show("Made by Reno Mardiputra");
        }
    }
}
