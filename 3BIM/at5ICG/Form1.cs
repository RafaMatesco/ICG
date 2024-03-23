using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace at5ICG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int angulo;
        bool buttonClick = false;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color intensidade = cor(0,0,0);
            if(buttonClick == true)
            {
                desenharQuadrante(400,400,100,intensidade,e);
                //desenharElipse(500,200,100,200, intensidade,e);
            }
            
        }

        public Color cor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        public Pen caneta(Color cor, int espessura)
        {
            return new Pen(cor, espessura);
        }

        public void pintap(int x, int y, Color cor, PaintEventArgs e)
        {
            e.Graphics.DrawLine(caneta(cor, 1), x, y, x + 1, y);
        }

        public void desenharQuadrante(int xc, int yc, int raio, Color cor, PaintEventArgs e)
        {
            
            int x;
            int y;
            double ang = 0;

            for (int i = 0; i < 90; i++)
            {
                ang = i * Math.PI / 180;
                x = (int)(xc - raio * Math.Cos(ang));
                y = (int)(yc + raio * Math.Sin(ang));
                pintap(x, y, cor, e);
                
            }
        }
        public void desenharElipse(int xc, int yc, int raiox, int raioy, Color cor, PaintEventArgs e)
        {
            
            int x;
            int y;
            double angulo;
            for (int i = 0; i < 360; i++)
            {
                angulo = i * Math.PI / 180;
                x = (int)(xc + raiox * Math.Cos(angulo));
                y = (int)(yc + raioy * Math.Sin(angulo));
                pintap(x, y, cor, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invalidate();
            buttonClick = true; 
            //angulo = int.Parse(textBox1.Text.ToString());
        }
    }
}
