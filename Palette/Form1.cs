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
        private int paletteNum = 1;
        private List<Color[]> paletts;

        public FormMain()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            _img = new Bitmap(512, 512);
            Image_Box.Image = _img;
            paletteChanger.SelectedIndex = 0;
            palletLoad();
        }

        private void palletLoad()
        {
            paletts = new List<Color[]>();


            Color[] palett1 = new Color[] {
                HexToRgb("#2b3634"),
                HexToRgb("#474848"),
                HexToRgb("#6e5f52"),
                HexToRgb("#a2856c"),
                HexToRgb("#a2856c"),
                HexToRgb("#dcb9a0"),
                HexToRgb("#f3dbc6"),
                HexToRgb("#fffefe")
            };

            Color[] palett2 = new Color[] {
                HexToRgb("#211e20"),
                HexToRgb("#555568"),
                HexToRgb("#a0a08b"),
                HexToRgb("#e9efec")
            };

            Color[] phoenix = new Color[] {
                HexToRgb("#330d10"),
                HexToRgb("#4d130f"),
                HexToRgb("#732017"),
                HexToRgb("#992817"),
                HexToRgb("#bf481d"),
                HexToRgb("#d97e16"),
                HexToRgb("#e5be22"),
                HexToRgb("#f2e749")
            };

            Color[] nintendo = new Color[] {
                HexToRgb("#243137"),
                HexToRgb("#3f503f"),
                HexToRgb("#768448"),
                HexToRgb("#acb56b")
            };

            Color[] goldRust = new Color[] {
                HexToRgb("#f6cd26"), 
                HexToRgb("#ac6b26"), 
                HexToRgb("#563226"), 
                HexToRgb("#331c17"), 
                HexToRgb("#bb7f57"), 
                HexToRgb("#725956"), 
                HexToRgb("#393939"), 
                HexToRgb("#202020")
            };


            paletts.Add(palett1);
            paletts.Add(palett2);
            paletts.Add(phoenix);
            paletts.Add(nintendo);
            paletts.Add(goldRust);

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
            Bitmap bitmap = (Bitmap)_img.Clone();
            FastBitmap fastBitmap = new FastBitmap(bitmap);

            int x, y;

            fastBitmap.Lock();

            for (y = 0; y < fastBitmap.Height; y++)
            {
                for (x = 0; x < fastBitmap.Width; x++)
                {
                    Color clr = fastBitmap.GetPixel(x, y);

                    int cclr = FindNearestColor(paletts[paletteChanger.SelectedIndex], clr);

                    fastBitmap.SetPixel(x, y, paletts[paletteChanger.SelectedIndex][cclr]);
                }
            }

            fastBitmap.Unlock();

            Image_Box.Image = bitmap;
        }

        private int GetDistance(Color current, Color match) //Euclidean sRGB
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
