using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Вычисление_по_формулам
{

    internal class NewTabControlf
    {
        public partial class NewTabControl : System.Windows.Forms.TabControl
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
                else base.WndProc(ref m);
            }
        }
    }

    public class NewTabPanel : System.Windows.Forms.Panel
    {

    }
}
