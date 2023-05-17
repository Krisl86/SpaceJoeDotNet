using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.Utils
{
    static class MenuDrawer
    {
        static readonly Color DefaultColor = Color.White;
        public static Texture2D? Background { get; set; }

        public static void DrawMainMenu(SpriteBatch spriteBatch, SpriteFont font)
        {
            int windowWidth = SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth;
            int widnowHeight = SpaceJoeGame.Instance.Graphics.PreferredBackBufferHeight;

            if (Background != null)
                spriteBatch.Draw(Background, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "[N]ew Game",
                new Vector2(windowWidth / 2, widnowHeight / 2 - 60), DefaultColor);

            spriteBatch.DrawStringCentered(false, font, "[L]oad Game",
                new Vector2(windowWidth / 2, widnowHeight / 2), DefaultColor);

            spriteBatch.DrawStringCentered(false, font, "[Q]uit",
                new Vector2(windowWidth / 2, widnowHeight / 2 + 60), DefaultColor);
        }
    }
}
