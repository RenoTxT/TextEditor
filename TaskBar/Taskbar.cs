using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public abstract class Taskbar
    {
        public bool exitTextEditor { get; set; }
        public string content {get; set;}
        public string title { get; set; }
        public bool dr { get; set; }

        public abstract void FuntionTaskbar();
    }
}
