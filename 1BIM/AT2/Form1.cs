using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LISTA
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

        public Color cor(int r, int g, int b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);
            return cor;
        }

        public Pen caneta()
        {
            Pen caneta = new Pen(cor(0, 0, 0), 2);
            return caneta;
        }


        public void linha(PaintEventArgs e, int xi, int yi, int xf, int yf, Pen caneta)
        {
            e.Graphics.DrawLine(caneta, xi, yi, xf, yf);
        }


        public void Estrela(PaintEventArgs e, int[] pontos, Pen caneta)
        {
            int[] pontosX = new int[12];
            int[] pontosY = new int[12];
            int pX = 0;
            int pY = 0;
            for (int x = 0; x < pontos.Length; x++)
            {
                if (x%2==0)
                {
                    pontosX[pX] = pontos[x];
                    pX++;
                }
                else
                {
                    pontosY[pY] = pontos[x];
                    pY++;
                }

            }
            for (int i = 0; i < 11; i++)
            {
                linha(e, pontosX[i], pontosY[i], pontosX[i+1], pontosY[i+1], caneta);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int[] pontos = new int[22];
            
            //X
            pontos[0] = 300; //1
            pontos[2] = 400;//2
            pontos[4] = 450;//3
            pontos[6] = 500;//4
            pontos[8] = 600;//5
            pontos[10] = 520;//6
            pontos[12] = 550;//7
            pontos[14] = 450;//8
            pontos[16] = 350;//9
            pontos[18] = 380;//10
            pontos[20] = 300;// 
            //Y
            pontos[1] = 300; //1
            pontos[3] = 300;//2
            pontos[5] = 200;//3
            pontos[7] = 300;//4
            pontos[9] = 300;//5
            pontos[11] = 350;//6
            pontos[13] = 450;//7
            pontos[15] = 400;//8
            pontos[17] = 450;//9
            pontos[19] = 350;//10
            pontos[21] = 300;//

            Estrela(e, pontos, caneta(0,0,0));



        }
    }
}
