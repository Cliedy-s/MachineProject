using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DinamicControlCreate
{
    public class DControls
    {
        /// <summary>
        /// 패널 생성 후 리턴
        /// </summary>
        /// <param name="location">(location==default) ? new Point(3, 3) : location</param>
        /// <param name="size"> (size == default) ? new Size(262, 420) : size</param>
        public Panel CreatePanel(string panName, Point location = default, Size size = default)
        {
            Panel panel = new Panel();
            //Temp Color
            panel.BackColor = SystemColors.ControlLightLight;
            panel.Name = panName;
            panel.Size = (size == default) ? new Size(262, 420) : size;
            panel.Location =(location==default) ? new Point(3, 3) : location;
            return panel;
        }
        /// <summary>
        /// 라벨 생성후 리턴
        /// </summary>
        /// <param name="size">autoSize ? new size(95, 15) : size</param>
        public Label CreateLabel(string controlName, string text,  Point location
            , Font font = default, bool autoSize = true, Size size = default
            , ContentAlignment contentAlignment = ContentAlignment.MiddleCenter )
        {
            Label label = new Label();
            label.Text = text;
            label.Name = controlName;
            label.Location = location;
            label.AutoSize = autoSize;
            label.Size = (autoSize) ? new Size(95, 15) : size;
            label.TextAlign = contentAlignment;
            label.Font = font;
            return label;
        }
        /// <summary>
        /// 리스트 박스 생성 후 리턴
        /// </summary>
        /// <param name="location">(location==default) ? new Point(3, 3) : location</param>
        /// <param name="size"> (size == default) ? new Size(255, 289) : size</param>
        /// <returns></returns>
        public ListBox CreateListBox(string controlName, Point location = default, Size size = default)
        {
            ListBox listBox = new ListBox();
            listBox.Name = "lstMachineLog";
            listBox.Location = (location==default) ? new Point(3, 3) : location;
            listBox.Size = (size == default) ? new Size(255, 289) : size;

            return listBox;

        }
        public Button CreateButton(string controlName, Size size = default, Point point = default)
        {
            Button btn = new Button();
            btn.Name = controlName;
            btn.Size = size;
            btn.Location = point;
            return btn;
        }
    }
}
