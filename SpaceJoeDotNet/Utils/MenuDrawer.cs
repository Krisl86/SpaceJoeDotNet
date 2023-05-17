using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.Utils
{
    static class MenuDrawer
    {
        static readonly int windowWidth = SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth;
        static readonly int widnowHeight = SpaceJoeGame.Instance.Graphics.PreferredBackBufferHeight;
        static readonly Color defaultColor = Color.White;
        public static Texture2D? MainMenuBackground { get; set; }
        public static Texture2D? GameOverMenuBackground { get; set; }

        public static void DrawMainMenu(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (MainMenuBackground != null)
                spriteBatch.Draw(MainMenuBackground, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "[N]ew Game",
                new Vector2(windowWidth / 2, widnowHeight / 2 - 60), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[L]oad Game",
                new Vector2(windowWidth / 2, widnowHeight / 2), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[Q]uit",
                new Vector2(windowWidth / 2, widnowHeight / 2 + 60), defaultColor);
        }

        public static void DrawGameOverMenu(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (MainMenuBackground != null)
                spriteBatch.Draw(GameOverMenuBackground, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "GAME OVER",
                new Vector2(windowWidth / 2, widnowHeight / 2 - 180), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[P]lay again",
                new Vector2(windowWidth / 2, widnowHeight / 2 - 60), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[S]hop",
                new Vector2(windowWidth / 2, widnowHeight / 2), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[Q]uit",
                new Vector2(windowWidth / 2, widnowHeight / 2 + 60), defaultColor);
        }
    }
}
