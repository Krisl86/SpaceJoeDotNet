using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using System;

namespace SpaceJoeDotNet.Utils
{
    static class MenuDrawer
    {
        static readonly Color defaultColor = Color.White;
        public static Texture2D? DefaultMenuBackground { get; set; }
        public static Texture2D? GameOverMenuBackground { get; set; }

        public static void DrawMainMenu(SpriteBatch spriteBatch, SpriteFont font,
            int windowWidth, int windowHeight, bool saveGameExists, bool loadError)
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

            if (loadError)
                spriteBatch.DrawStringCentered(false, font, "Error with loading save file...",
                new Vector2(windowWidth / 2, 680), defaultColor);
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

            spriteBatch.DrawStringCentered(false, font, "[V]iew Highscores",
                new Vector2(windowWidth / 2, windowHeight / 2 + 120), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[Q]uit",
                new Vector2(windowWidth / 2, windowHeight / 2 + 180), defaultColor);
        }

        public static void DrawShopMenu(SpriteBatch spriteBatch, SpriteFont font, Player player, 
            int windowWidth, int windowHeight, UpgradesManager upgradesManager)
        {
            if (DefaultMenuBackground != null)
                spriteBatch.Draw(DefaultMenuBackground, new Vector2(0, 0), Color.White);

            spriteBatch.DrawStringCentered(false, font, "[CRD]", new Vector2(windowWidth / 2, 20), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"{player.TotalScore}",
                new Vector2(windowWidth / 2, 40), defaultColor);

            int baseY1 = 80;

            spriteBatch.DrawStringCentered(false, font, $"[1] [200CRD] Weapon Damage", new Vector2(windowWidth / 2, baseY1 * 1), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"[Value]: {player.Weapon.Damage}", new Vector2(windowWidth / 2, baseY1 * 1 + 30), defaultColor);

            spriteBatch.DrawStringCentered(false, font, $"[1] [350CRD] Weapon Cooldown", new Vector2(windowWidth / 2, baseY1 * 2), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"[Value]: {player.Weapon.CooldownTime:0.00}", new Vector2(windowWidth / 2, baseY1 * 2 + 30), defaultColor);

            spriteBatch.DrawStringCentered(false, font, $"[1] [500CRD] Weapon Heat Limit", new Vector2(windowWidth / 2, baseY1 * 3), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"[Value]: {player.Weapon.HeatLimit}", new Vector2(windowWidth / 2, baseY1 * 3 + 30), defaultColor);

            spriteBatch.DrawStringCentered(false, font, $"[1] [100CRD] Shield Capacity", new Vector2(windowWidth / 2, baseY1 * 4), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"[Value]: {player.Shield.MaxHitPoints}", new Vector2(windowWidth / 2, baseY1 * 4 + 30), defaultColor);

            spriteBatch.DrawStringCentered(false, font, $"[1] [350CRD] Shield Refresh Delay", new Vector2(windowWidth / 2, baseY1 * 5), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"[Value]: {player.Shield.RecoveryDelay:0.00}", new Vector2(windowWidth / 2, baseY1 * 5 + 30), defaultColor);

            spriteBatch.DrawStringCentered(false, font, $"[1] [50CRD] Shield Refresh Time", new Vector2(windowWidth / 2, baseY1 * 6), defaultColor);
            spriteBatch.DrawStringCentered(false, font, $"[Value]: {player.Shield.RecoveryTime:0.00}", new Vector2(windowWidth / 2, baseY1 * 6 + 30), defaultColor);

            spriteBatch.DrawStringCentered(false, font, "[B]ack to menu",
                new Vector2(windowWidth / 2, windowHeight - 40), defaultColor);
        }
    }
}
