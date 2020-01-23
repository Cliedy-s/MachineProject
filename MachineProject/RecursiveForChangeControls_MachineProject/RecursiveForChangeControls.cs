using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursiveForChangeControls_MachineProject
{
    public class RecursiveForChangeControls
    {
        public delegate void actions(Control control);

        /// <summary>
        /// 컨트롤 컬렉션과 델리게이트를 넣으면 컨트롤과 컨트롤 자식들에게 해당 델리게이트를 실행한다.
        /// (example) private void ChangeFont(Control control)
        /// {
        ///     Font font = control.Font;
        ///     control.Font = new Font("나눔고딕", font.Size, font.Style);
        /// }
        /// </summary>
        /// <param name="action">void actions(Control control)</param>
        public void ChangeControls(Control.ControlCollection controls, actions action)
        {
            foreach (Control item in controls)
            {
                childControls(item);
            }

            void childControls(Control control)
            {
                action(control);
                foreach (Control item in control.Controls)
                {
                    childControls(item);
                }
            }
        }
    }
}
