using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;
using Color = Microsoft.Xna.Framework.Color;

namespace SpaceJoeDotNet.Utils;

static class HudDrawer
{
    const int XMargin = 20;
    const int YMargin = 20;
    static readonly Color DefaultHudColor = Color.White;
    static readonly Color AlertHudColor = Color.Red;

    public static void DrawHud(SpriteBatch spriteBatch, SpriteFont font, Player player)
    {
        DrawWeaponHeatInfo(spriteBatch, font, player);
        DrawScoreHpShield(spriteBatch, font, player);
    }

    static void DrawWeaponHeatInfo(SpriteBatch spriteBatch, SpriteFont font, Player player)
    {
        int windowWidth = SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth;
        
        spriteBatch.DrawStringCentered(false, font, "[ HEAT ]",
            new Vector2(windowWidth / 2, 75), DefaultHudColor);
        
        for (int i = 0; i < player.Weapon.CurrentHeat; i++)
        {
            spriteBatch.DrawString(font, "*",
                new Vector2(windowWidth / 2 + i * 15, 95), DefaultHudColor);
            spriteBatch.DrawString(font, "*",
                new Vector2(windowWidth / 2 - i * 15, 95), DefaultHudColor);
        }
        
        if (player.Weapon.CurrentHeat == player.Weapon.HeatLimit)
            spriteBatch.DrawStringCentered(false, font, "[ WEAPON OVERHEATING ]",
                new Vector2(windowWidth / 2, 200), AlertHudColor);
    }

    static void DrawScoreHpShield(SpriteBatch spriteBatch, SpriteFont font, Player player)
    {
        int windowWidth = SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth;

        string score = "[ SCR ]";
        var size = font.MeasureString(score);
        spriteBatch.DrawString(font, score, new Vector2(XMargin, YMargin), DefaultHudColor);   
        spriteBatch.DrawStringCentered(false, font, player.Score.ToString(), 
            new Vector2(XMargin + size.X / 2, YMargin + 20), DefaultHudColor);
        
        spriteBatch.DrawStringCentered(false, font, "[ HLL ]", 
            new Vector2(windowWidth / 2, YMargin), DefaultHudColor);
        spriteBatch.DrawStringCentered(false, font, player.HullPoints.ToString(),
            new Vector2(windowWidth / 2, YMargin + 20), DefaultHudColor);

        string shield = "[ SLD ]";
        size = font.MeasureString(shield);
        spriteBatch.DrawString(font, shield, new Vector2(windowWidth - size.X - XMargin, YMargin), 
            DefaultHudColor);
        spriteBatch.DrawStringCentered(false, font, player.ShieldPoints.ToString(),
            new Vector2(windowWidth - size.X / 2 - XMargin, YMargin + 20), DefaultHudColor);

        
        if (player.HullPoints < 30)
            spriteBatch.DrawStringCentered(false, font, "[ SEVERE DAMAGE ]",
                new Vector2(windowWidth / 2, 250), AlertHudColor);
        
        if (player.ShieldPoints == 0)
            spriteBatch.DrawStringCentered(false, font, "[ SHIELDS DOWN ]",
                new Vector2(windowWidth / 2, 300), AlertHudColor);
    }
}