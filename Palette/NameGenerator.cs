using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palette
{
    class NameGenerator
    {
        public string Generate(int lenth)
        {
            char[] alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            var _rnd = new Random();
            string name = null;

            for (int i = 0; i < lenth; i++)
            {
                name += alph[_rnd.Next(0, alph.Length)];
            }

            return name;
        }
    }
}
