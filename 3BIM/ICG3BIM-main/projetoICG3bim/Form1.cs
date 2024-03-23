
/*Colegio Técnico Antônio Teixeira Fernandes (Univap)
 *Curso Técnico em Informática - Data de Entrega: 30 / 08 / 2023
 * Autores do Projeto: Rafael Giordano Matesco 
 *                      Paulo Renato Durante 
 *
 * Turma: 3H
 * Atividade Proposta em aula
 * Observação: Nada.
 * 
 * 
 * ******************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace projetoICG3bim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //-------------------- VARIAVEIS --------------------

        int coluna = 0;
        int linha = 0;
        bool isProcessado = false;
        Color cor;
        Bitmap imgCozinha = new Bitmap("C:\\Imagens\\Imagem_A.jpg");
        Bitmap imgPanela = new Bitmap("C:\\Imagens\\Panela.jpg");

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = imgCozinha;
        }

        //-------------------- IMAGEM CINZA --------------------
        private Bitmap imgCinza(Bitmap cozinha)
        {
            coluna = cozinha.Width; // O número colunas 
            linha = cozinha.Height; // O número de linhas
            Bitmap imgnova = new Bitmap(coluna, linha);

            cor = new Color();
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = cozinha.GetPixel(i, j).R;
                    double g = cozinha.GetPixel(i, j).G;
                    double b = cozinha.GetPixel(i, j).B;

                    double K = r * 0.3 + g * 0.59 + b * 0.11;

                    cor = Color.FromArgb((int)K, (int)K, (int)K);
                    imgnova.SetPixel(i, j, cor);

                }
            }
            return imgnova;
        }

        //-------------------- IMAGEM P/B ----------------------
        private Bitmap imgPB(Bitmap cozinha)
        {
            coluna = cozinha.Width; // O número colunas 
            linha = cozinha.Height; // O número de linhas
            Bitmap imgnova = new Bitmap(coluna, linha);
            cor = new Color();
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    double r = cozinha.GetPixel(i, j).R;
                    double g = cozinha.GetPixel(i, j).G;
                    double b = cozinha.GetPixel(i, j).B;

                    double K = r * 0.3 + g * 0.59 + b * 0.11;

                    if (K >= 127)
                        K = 255;
                    else
                        K = 0;

                    cor = Color.FromArgb((int)K, (int)K, (int)K);
                    imgnova.SetPixel(i, j, cor);

                }
            }

            return imgnova;
        }

        //-------------------- REMOVE FUNDO --------------------
        private Bitmap tiraAmarelo()
        {
            int coluna = imgPanela.Width; // O número colunas 
            int linha = imgPanela.Height; // O número de linhas
            Bitmap imgnova = new Bitmap(coluna, linha);
            Color cor = new Color();
            for (int i = 0; i <= coluna - 1; i++)
            {
                for (int j = 0; j <= linha - 1; j++)
                {
                    int r = imgPanela.GetPixel(i, j).R;
                    int g = imgPanela.GetPixel(i, j).G;
                    int b = imgPanela.GetPixel(i, j).B;

                    if (r*0.5+g*0.5 >= 200 && (r*0.33 + g * 0.33 + b * 0.33) <= 200)
                    {
                        imgnova.SetPixel(i, j, Color.FromArgb(0, 0, 0, 0));
                    }
                    else
                    {
                        cor = Color.FromArgb(r, g, b);
                        imgnova.SetPixel(i, j, cor);
                    }

                }
            }
            return imgnova;
        }

        //-------------------- COLOCA PANELA NA COZINHA --------------------
        private Bitmap SobrepoeImagem()
        {
            Bitmap panela = tiraAmarelo();
            Bitmap img_resultado = new Bitmap(imgCozinha);

            for (int x = 0; x < panela.Width; x++)
            {
                for (int y = 0; y < panela.Height; y++)
                {
                    Color pixelSobre = panela.GetPixel(x, y);

                    // Se a cor do pixel da sobreposição não for transparente, aplicar sobreposição
                    if (pixelSobre.A != 0)
                    {
                        img_resultado.SetPixel(x+135, y, pixelSobre);
                    }
                }
            }
            return img_resultado;

        }

        private void button1_Click(object sender, EventArgs e) //botao PROCESSAR
        {
            if (!isProcessado)
            {

                //cinza
                Bitmap imgNova = imgCinza(SobrepoeImagem());
                pictureBox4.Image = imgNova;
                imgNova.Save("C:\\Imagens\\tons_de_cinza.jpg");

                //preto e branco
                imgNova = imgPB(SobrepoeImagem());
                pictureBox5.Image = imgNova;
                imgNova.Save("C:\\Imagens\\binaria.jpg");

                //coloca panela na cozinha
                Bitmap img_resultado = SobrepoeImagem();
                pictureBox1.Image = img_resultado;
                pictureBox3.Image = img_resultado;
                img_resultado.Save("C:\\Imagens\\original_colorida.jpg");

                isProcessado = true;

            }
            else
            {
                MessageBox.Show("Imagens já processadas!","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e){}
    }
}
