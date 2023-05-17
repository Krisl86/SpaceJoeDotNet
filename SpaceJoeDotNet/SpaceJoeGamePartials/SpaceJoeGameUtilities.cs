﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        // from https://stackoverflow.com/questions/106712/how-to-make-sure-a-font-exists-before-using-it-with-net
        static bool FontExists(string fontName)
        {
            var fontFamilies = new InstalledFontCollection().Families;
            return fontFamilies.Any(f => f.Name == fontName);
        }
    }
}
