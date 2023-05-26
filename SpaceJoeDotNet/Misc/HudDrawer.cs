using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Utils;

static class HudDrawer
{
    const int XMargin = 20;
    const int YMargin = 20;
    static readonly Color DefaultHudColor = Color.White;
    static readonly Color AlertHudColor = Color.Red;

    public static void DrawHud(SpriteBatch spriteBatch, SpriteFont font, Player player, int windowWidth)
    {
        DrawWeaponHeatInfo(spriteBatch, font, player, windowWidth);
        DrawScoreHpShield(spriteBatch, font, player, windowWidth);
        DrawShieldAndHullInfo(spriteBatch, font, player, windowWidth);
        DrawLowShieldInfo(spriteBatch, font, player, windowWidth);
    }

    static void DrawWeaponHeatInfo(SpriteBatch spriteBatch, SpriteFont font, Player player, int windowWidth)
    {
        spriteBatch.DrawStringCentered(false, font, "[ HEAT ]",
            new Vector2(windowWidth / 2, 75), DefaultHudColor);

        for (int i = 0; i < player.Weapon.CurrentHeat; i++)
        {
            spriteBatch.DrawString(font, "*",
                new Vector2(windowWidth / 2 + i * 5, 95), DefaultHudColor);
            spriteBatch.DrawString(font, "*",
                new Vector2(windowWidth / 2 - i * 5, 95), DefaultHudColor);
        }

        if (player.Weapon.CurrentHeat == player.Weapon.HeatLimit)
            spriteBatch.DrawStringCentered(false, font, "[ WEAPON OVERHEATING ]",
                new Vector2(windowWidth / 2, 200), AlertHudColor);
    }

    static void DrawScoreHpShield(SpriteBatch spriteBatch, SpriteFont font, Player player, int windowWidth)
    {
        string score = "[ SCR ]";
        var size = font.MeasureString(score);
        spriteBatch.DrawString(font, score, new Vector2(XMargin, YMargin), DefaultHudColor);
        spriteBatch.DrawStringCentered(false, font, player.Score.ToString(),
            new Vector2(XMargin + size.X / 2, YMargin + 20), DefaultHudColor);

        spriteBatch.DrawStringCentered(false, font, "[ HLL ]",
            new Vector2(windowWidth / 2, YMargin), DefaultHudColor);
        spriteBatch.DrawStringCentered(false, font, player.HitPoints.ToString(),
            new Vector2(windowWidth / 2, YMargin + 20), DefaultHudColor);

        string shield = "[ SLD ]";
        size = font.MeasureString(shield);
        spriteBatch.DrawString(font, shield, new Vector2(windowWidth - size.X - XMargin, YMargin),
            DefaultHudColor);
        spriteBatch.DrawStringCentered(false, font, player.Shield.HitPoints.ToString(),
            new Vector2(windowWidth - size.X / 2 - XMargin, YMargin + 20),
            player.Shield.HitPoints < player.Shield.MaxHitPoints ? AlertHudColor : DefaultHudColor);
    }

    static void DrawShieldAndHullInfo(SpriteBatch spriteBatch, SpriteFont font, Player player, int windowWidth)
    {
        if (player.HitPoints < 30)
            spriteBatch.DrawStringCentered(false, font, "[ SEVERE DAMAGE ]",
                new Vector2(windowWidth / 2, 250), AlertHudColor);
    }

    static void DrawLowShieldInfo(SpriteBatch spriteBatch, SpriteFont font, Player player, int windowWidth)
    {
        if (player.Shield.HitPoints == 0)
        {
            spriteBatch.DrawStringCentered(false, font, "[ SHIELDS DOWN ]",
                new Vector2(windowWidth / 2, 300), AlertHudColor);

            for (int i = (int)player.Shield.RecoveryDelay;
            i >= player.Shield.RecoveryDelay - (int)player.Shield.DelayCounter;
                i--)
            {
                spriteBatch.DrawString(font, "*",
                    new Vector2(windowWidth / 2 + i * 10, 320), AlertHudColor);
                spriteBatch.DrawString(font, "*",
                    new Vector2(windowWidth / 2 - i * 10, 320), AlertHudColor);
            }
        }
    }
}