using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj1
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

        public Pen propsCaneta(int r, int g, int b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);
            Pen caneta = new Pen(cor, 1);
            return caneta;
        }

        bool dadosEnviados = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            int r = 0;
            int g = 0;
            int b = 0;

            int x1 = 0;
            int y1 = 540;
            int x2 = 970;
            int y2 = 0;

            Pen caneta = propsCaneta(r, g, b);

            //reta xs
            e.Graphics.DrawLine(caneta, x1, y1, x1 + 1920, y1);
            //reta y
            e.Graphics.DrawLine(caneta, x2, y2, x2, y2 + 1080);

            if (dadosEnviados == true)
            {
                r = 255;
                g = 0;
                b = 0;
                caneta = propsCaneta(r, g, b);
                e.Graphics.DrawLine(caneta, xi + 960, yi + 540, xf + 960, (y + 540));
                dadosEnviados = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        float xi = 0;
        float xf = 0;
        float yi = 0;
        float m = 0;
        float b = 0;
        float y = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Invalidate();
            dadosEnviados = true;   

            xi = float.Parse(textBox1.Text); 
            xf = float.Parse(textBox5.Text);
            yi = float.Parse(textBox3.Text);
            m = float.Parse(textBox2.Text);   
            b = float.Parse(textBox4.Text);

            yi = -yi;
            b = -b;
            m = -m;

            y = m * xf + b;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
