using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Schedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] dol = new int[] { 27, 26, 26, 26, 26, 27, 28, 29, 29, 29, 29, 29 };
        int[] evr = new int[] { 32, 31, 31, 30, 30, 30, 31, 33, 32, 31, 30, 30 };
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.DarkGray, 1.0f);
            string text;
            Font font = new Font("Courier New", 12.0f, FontStyle.Italic | FontStyle.Bold);
            int x = 100, y = 100;
            for (int i = 0; i < 7; i++)
            {
                text = $"{35 - (5 * i)}";
                SizeF sizeF = g.MeasureString(text, font);
                RectangleF recF = new RectangleF(new Point(x - 40, y - 10), sizeF);
                g.DrawString(text, font, Brushes.Black, recF);
                g.DrawLine(pen, x - 10, y, x + (40 * 12), y);
                y += 30;
            }
            pen = new Pen(Color.Black, 3.0f);
            g.DrawLine(pen, x, y, x + (40 * 12), y);
            for (int j = 0; j < 13; j++)
            {
                if (j == 0)
                {
                    pen = new Pen(Color.Black, 3.0f);
                    g.DrawLine(pen, x, y, x, y - (30 * 7));
                }
                else
                {
                    text = $"{j}";
                    SizeF sizeF = g.MeasureString(text, font);
                    RectangleF recF = new RectangleF(new Point(x - 10, y + 15), sizeF);
                    g.DrawString(text, font, Brushes.Black, recF);
                    pen = new Pen(Color.DarkGray, 1.0f);
                    g.DrawLine(pen, x, y + 10, x, y - (30 * 7));
                }
                x += 40;
            }
            x = 100; y = 100;
            pen = new Pen(Color.LightSkyBlue, 2.0f);
            for (int i = 0; i < 11; i++)
            {
                x += 40;
                g.DrawLine(pen, x, y + (30 * 7) - (dol[i] * 6), x + 40, y + (30 * 7) - (dol[i + 1] * 6));
            }
            x = 100; y = 100;
            pen = new Pen(Color.DarkOrange, 2.0f);
            for (int i = 0; i < 11; i++)
            {
                x += 40;
                g.DrawLine(pen, x, y + (30 * 7) - (evr[i] * 6), x + 40, y + (30 * 7) - (evr[i + 1] * 6));
            }

        }
    }
}
