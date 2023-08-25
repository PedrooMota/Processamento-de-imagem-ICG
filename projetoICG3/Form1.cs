using System.Drawing;
using System.Windows.Forms;

namespace projetoICG3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\Imagens\\Imagem_A.jpg");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processarImagem();
        }

        private void processarImagem()
        {
            grayLevel();
            duasCores();
            alternado();
            binarizacao();
            pictureBox1.Image = removerFundo();
        }

        // Primitiva do GrayLevel
        private Bitmap grayLevel()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            int altura = bitmap.Height;
            int largura = bitmap.Width;

            Bitmap newBitmap = new Bitmap(largura, altura);

            for (int j = 0; j < altura; j++)
            {
                for (int i = 0; i < largura; i++)
                {
                    Color pixel = bitmap.GetPixel(i, j);

                    Byte red, green, blue;

                    red = pixel.R;
                    green = pixel.G;
                    blue = pixel.B;

                    byte res = (byte)((red * 0.3) + (green * 0.59) + (blue * 0.11));

                    Color gray = gerarCor(res, res, res);

                    newBitmap.SetPixel(i, j, gray);
                }
            }

            newBitmap.Save("C:\\Imagens\\Imagem2.jpg");
            return newBitmap;
        }

        // Primitiva da Binarização
        private Bitmap binarizacao()
        {
            Bitmap bitmap = grayLevel();

            int altura = bitmap.Height;
            int largura = bitmap.Width;

            Bitmap newBitmap = new Bitmap(largura, altura);

            Color White = gerarCor(255, 255, 255);
            Color Black = gerarCor(0, 0, 0);

            for (int j = 0; j < altura; j++)
            {
                for (int i = 0; i < largura; i++)
                {
                    Color pixel = bitmap.GetPixel(i, j);

                    Byte red;

                    red = pixel.R;

                    if (red >= 127)
                    {
                        newBitmap.SetPixel(i, j, White);
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, Black);
                    }
                }
            }

            newBitmap.Save("C:\\Imagens\\Imagem3.jpg");
            return newBitmap;
        }

        private Bitmap removerFundo()
        {
            Bitmap panelaBitmap = new Bitmap("C:\\Imagens\\Panela.jpg");
            Bitmap fundoBitmap = new Bitmap("C:\\Imagens\\Imagem_A.jpg");

            int altura = panelaBitmap.Height;
            int largura = panelaBitmap.Width;

            for (int j = 0; j < altura-1; j++)
            {
                for (int i = 0; i < largura-1; i++)
                {
                    Color pixel = panelaBitmap.GetPixel(i, j);

                    Byte red, green, blue;

                    red = pixel.R;
                    green = pixel.G;
                    blue = pixel.B;

                    if (!(red > 130 && green > 130 && blue < 140))
                        fundoBitmap.SetPixel(i + 140, j, pixel);
                }
            }

            fundoBitmap.Save("C:\\Imagens\\Imagem1.jpg");
            return fundoBitmap;
        }
        private Bitmap alternado()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            int altura = bitmap.Height;
            int largura = bitmap.Width;

            Bitmap newBitmap = new Bitmap(largura, altura);

            for (int j = 0; j < altura; j++)
            {
                for (int i = 0; i < largura; i++)
                {
                    if (i > largura / 2)
                    {
                        Color pixel = bitmap.GetPixel(i, j);

                        Byte red;

                        red = pixel.R;

                        Color White = gerarCor(255, 255, 255);
                        Color Black = gerarCor(0, 0, 0);

                        if (red >= 127)
                        {
                            newBitmap.SetPixel(i, j, White);
                        }
                        else
                        {
                            newBitmap.SetPixel(i, j, Black);
                        }
                    }
                    else
                    {
                        Color pixel = bitmap.GetPixel(i, j);

                        Byte red, green, blue;

                        red = pixel.R;
                        green = pixel.G;
                        blue = pixel.B;

                        byte res = (byte)((red * 0.3) + (green * 0.59) + (blue * 0.11));

                        Color gray = gerarCor(res, res, res);

                        newBitmap.SetPixel(i, j, gray);
                    }

                }
            }
            newBitmap.Save("C:\\Imagens\\Imagem5.jpg");
            return newBitmap;
        }

        private Bitmap duasCores()
        {
            Bitmap bitmap = grayLevel();

            int largura = bitmap.Width;
            int altura = bitmap.Height;

            Color Blue = gerarCor(0, 0, 255);
            Color Green = gerarCor(0, 255, 0);

            Bitmap newBitmap = new Bitmap(largura, altura);

            for (int j = 0; j < altura; j++)
            {
                for (int i = 0; i < largura; i++)
                {
                    if (i > largura / 2)
                    {
                        newBitmap.SetPixel(i, j, Blue);
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, Green);
                    }

                }
            }
            newBitmap.Save("C:\\Imagens\\Imagem4.jpg");
            return newBitmap;
        }

        private Color gerarCor(byte red, byte green, byte blue)
        {
            return Color.FromArgb(red, green, blue);
        }
    }
}