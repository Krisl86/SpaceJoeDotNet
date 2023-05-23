﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Utils
{
    static class MenuDrawer
    {
        static readonly Color defaultColor = Color.White;
        public static Texture2D? DefaultMenuBackground { get; set; }
        public static Texture2D? GameOverMenuBackground { get; set; }

        public static void DrawMainMenu(SpriteBatch spriteBatch, SpriteFont font,
            int windowWidth, int windowHeight, bool saveGameExists)
        {
            if (DefaultMenuBackground != null)
                spriteBatch.Draw(DefaultMenuBackground, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "[N]ew Game",
                new Vector2(windowWidth / 2, windowHeight / 2 - 60), defaultColor);

            if (saveGameExists)
                spriteBatch.DrawStringCentered(false, font, "[L]oad Game",
                    new Vector2(windowWidth / 2, windowHeight / 2), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[Q]uit",
                new Vector2(windowWidth / 2, windowHeight / 2 + 60), defaultColor);
        }

        public static void DrawGameOverMenu(SpriteBatch spriteBatch, SpriteFont font,
            int windowWidth, int windowHeight, bool gameSaved)
        {
            if (DefaultMenuBackground != null)
                spriteBatch.Draw(GameOverMenuBackground, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "GAME OVER",
                new Vector2(windowWidth / 2, windowHeight / 2 - 180), defaultColor);

            if (!gameSaved)
                spriteBatch.DrawStringCentered(false, font, "[S]ave progress",
                    new Vector2(windowWidth / 2, windowHeight / 2 - 60), defaultColor);
            else
                spriteBatch.DrawStringCentered(false, font, "Game Saved...",
                    new Vector2(windowWidth / 2, 680), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[P]lay again",
                new Vector2(windowWidth / 2, windowHeight / 2), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[U]pgrades",
                new Vector2(windowWidth / 2, windowHeight / 2 + 60), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[Q]uit",
                new Vector2(windowWidth / 2, windowHeight / 2 + 120), defaultColor);
        }

        public static void DrawShopMenu(SpriteBatch spriteBatch, SpriteFont font, Player player, 
            int windowWidth, int windowHeight)
        {
            if (DefaultMenuBackground != null)
                spriteBatch.Draw(DefaultMenuBackground, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "[CRD]", new Vector2(windowWidth / 2, 20), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"{player.TotalScore}",
                new Vector2(windowWidth / 2, 40), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[B]ack to menu",
                new Vector2(windowWidth / 2, windowHeight - 40), defaultColor);
        }
    }
}
