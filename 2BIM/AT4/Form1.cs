using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace at_2_bimestre
{
    public partial class Form1 : Form
    {

        int click;
        int[] pontos = new int[4] { 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Color cor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);

        }
        public Pen caneta(Color cor, int espessura)
        {
            return new Pen(cor, espessura);
        }
        public void retaBreseham(int[] pontos, Pen caneta, PaintEventArgs e)
        {
            e.Graphics.DrawLine(caneta, pontos[0], pontos[1], pontos[2], pontos[3]);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (click % 2 == 0)
            {
                retaBreseham(pontos, caneta(cor(255, 0, 0), 2), e);
            }
            else
            {
                retaBreseham(pontos, caneta(cor(255, 0, 0), 0), e);
            }




        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click++;


            if (click % 2 == 1)
            {
                pontos[0] = e.X;
                pontos[1] = e.Y;
            }
            else
            {
                pontos[2] = e.X;
                pontos[3] = e.Y;
                Invalidate();
            }

        }
    }
}

