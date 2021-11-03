using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastBitmapLib;

namespace Palette
{
    public partial class FormMain : Form
    {
        private Bitmap _img;
        private int _steps = 5;

        public FormMain()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            _img = new Bitmap(512, 512);
            Image_Box.Image = _img;
        }

        private Color HexToRgb(string hex)
        {
            char[] hexChar = hex.ToCharArray();

            string rawR = hexChar[1].ToString() + hexChar[2].ToString();
            string rawG = hexChar[3].ToString() + hexChar[4].ToString();
            string rawB = hexChar[5].ToString() + hexChar[6].ToString();

            int R = Convert.ToInt32(rawR, 16);
            int G = Convert.ToInt32(rawG, 16);
            int B = Convert.ToInt32(rawB, 16);

            return Color.FromArgb(R, G, B);
        }

        private void Render_Click(object sender, EventArgs e)
        {
            Color[] clrs = new Color[] {
                HexToRgb("#000000"),
                HexToRgb("#0000d8"),
                HexToRgb("#0000ff"),
                HexToRgb("#d80000"),
                HexToRgb("#ff0000"),
                HexToRgb("#d800d8"),
                HexToRgb("#ff00ff"),
                HexToRgb("#00d800"),
                HexToRgb("#00ff00"),
                HexToRgb("#00d8d8"),
                HexToRgb("#00ffff"),
                HexToRgb("#d8d800"),
                HexToRgb("#ffff00"),
                HexToRgb("#d8d8d8"),
                HexToRgb("#ffffff"),
            };


            Bitmap bitmap = (Bitmap)_img.Clone();
            FastBitmap fastBitmap = new FastBitmap(bitmap);

            int x, y;

            fastBitmap.Lock();

            for (y = 0; y < fastBitmap.Height; y++)
            {
                for (x = 0; x < fastBitmap.Width; x++)
                {
                    Color clr = fastBitmap.GetPixel(x, y);

                    int cclr = FindNearestColor(clrs, clr);

                    fastBitmap.SetPixel(x, y, clrs[cclr]);
                }
            }

            fastBitmap.Unlock();

            Image_Box.Image = bitmap;
        }

        private int GetDistance(Color current, Color match)
        {
            int redDifference;
            int greenDifference;
            int blueDifference;

            redDifference = current.R - match.R;
            greenDifference = current.G - match.G;
            blueDifference = current.B - match.B;

            return redDifference * redDifference + greenDifference * greenDifference + blueDifference * blueDifference;
        }

        private int FindNearestColor(Color[] map, Color current)
        {
            int shortestDistance;
            int index;

            index = -1;
            shortestDistance = int.MaxValue;

            for (int i = 0; i < map.Length; i++)
            {
                Color match;
                int distance;

                match = map[i];
                distance = GetDistance(current, match);

                if (distance < shortestDistance)
                {
                    index = i;
                    shortestDistance = distance;
                }
            }

            return index;
        }

        private double closestStep(int clr, int maxClr)
        {
            //return Math.Round(steps * value / 255 * Math.Floor(255 / (double)steps));
            var nClr = Math.Round((double)clr / 255 * maxClr * 255);

            if (nClr > 255)
            {
                nClr = 255;
            }
            
            return nClr;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            var NGen = new NameGenerator();
            var name = NGen.Generate(12);

            try
            {
                Image_Box.Image.Save($"{Directory.GetCurrentDirectory()}/{name}.png");
            }
            catch (ArgumentException)//защита от одинаковых имён.
            {
                MessageBox.Show("Произошла небольшая ошибка, попробуйте ещё раз");
            }
            finally
            {
                if (CheckSave.Checked)
                {
                    Process.Start("explorer.exe", @$"{Directory.GetCurrentDirectory()}");
                }
                else
                {
                    MessageBox.Show($"Файл сохранён в {Directory.GetCurrentDirectory()}", "Сохранение");
                }
            }
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            var OPF = new OpenFileDialog();
            OPF.Filter = "Файлы .png|*.png|Файлы .jpg|*.jpg| Файлы .jpeg| *.jpg";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                Image_Box.Image = Image.FromFile(OPF.FileName);
                _img = new Bitmap(Image_Box.Image);
            }
            else
            {
                OPF.Dispose();
            }
        }
    }
}
