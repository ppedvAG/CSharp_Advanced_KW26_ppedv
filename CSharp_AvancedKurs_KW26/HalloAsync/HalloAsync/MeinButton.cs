using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloAsync
{
    public class MeinButton : Button
    {
        [Browsable(false)]
        public override Color BackColor
        {
            get => base.BackColor;

            set
            {
                if (value == Color.Pink)
                    base.BackColor = Color.Black;
                else
                    base.BackColor = value;
            }
        }

        public MeinButton()
            :base()
        {
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), this.ClientRectangle);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.FillEllipse(new HatchBrush(HatchStyle.Cross, Color.Yellow, BackColor), this.ClientRectangle);

            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var myFont = new Font(SystemFonts.DefaultFont.FontFamily, 26, FontStyle.Bold);
            var brush = new LinearGradientBrush(ClientRectangle, Color.Magenta, Color.Cyan, 90f);
            pevent.Graphics.DrawString(Text, myFont, brush, ClientRectangle, sf);

            //Text = $"Paints: {c++}";//witzig aber dumm
        }
        int c = 0;
    }
}
