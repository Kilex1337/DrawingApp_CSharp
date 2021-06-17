using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp_CSharp
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        int penWidth = 12;
        bool moving = false;
        Pen pen;
        // string lastUsedColor;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, penWidth);
            // lastUsedColor = "Black";
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            // lastUsedColor = p.BackColor.ToString();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Triangle;
        }

        private void buttonDiamond_Click(object sender, EventArgs e)
        {
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
        }

        private void buttonRound_Click(object sender, EventArgs e)
        {
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void buttonArrow_Click(object sender, EventArgs e)
        {
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if(penWidth < 2)
            {
                MessageBox.Show("Can't go below 1px");
            }
            else
            {
                penWidth -= 1;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pen = new Pen(Color.Black, penWidth);
                pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                labelSize.Text = penWidth.ToString();
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if(penWidth >= 50)
            {
                MessageBox.Show("Can't go above 50px");
            }
            else
            {
                penWidth += 1;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                pen = new Pen(Color.Black, penWidth);
                pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                labelSize.Text = penWidth.ToString();
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                // lastUsedColor = colorDialog1.Color.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog2.Color;
            }
        }
    }
}
