using Microsoft.Xna.Framework;
using System.Drawing.Text;
using System.Linq;

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

        void ResetGame()
        {
            _player.Reset();
            _asteroidManager.Reset();
            _projectileManager.Reset();
        }
    }
}
