using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;
using Color = Microsoft.Xna.Framework.Color;

namespace SpaceJoeDotNet;

static class HudDrawer
{
    const int XMargin = 20;
    const int YMargin = 20;
    static readonly Color DefaultHudColor = Color.White;

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
        
        for (int i = 0; i < player.CurrentWeapon.CurrentHeat; i++)
        {
            spriteBatch.DrawString(font, "*",
                new Vector2(windowWidth / 2 + i * 15, 95), DefaultHudColor);
            spriteBatch.DrawString(font, "*",
                new Vector2(windowWidth / 2 - i * 15, 95), DefaultHudColor);
        }
        
        if (player.CurrentWeapon.CurrentHeat == player.CurrentWeapon.HeatLimit)
            spriteBatch.DrawStringCentered(false, font, "[ WEAPON OVERHEATING ]",
                new Vector2(windowWidth / 2, 200), Color.Red);
    }

    static void DrawScoreHpShield(SpriteBatch spriteBatch, SpriteFont font, Player player)
    {
        int windowWidth = SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth;
        
        spriteBatch.DrawString(font, "[ SCR ]", new Vector2(XMargin, YMargin), DefaultHudColor);   
        
        spriteBatch.DrawStringCentered(false, font, "[ HLL ]", 
            new Vector2(windowWidth / 2, YMargin), DefaultHudColor);

        string shield = "[ SLD ]";
        var size = font.MeasureString(shield);
        spriteBatch.DrawString(font, shield, new Vector2(windowWidth - size.X - XMargin, YMargin), DefaultHudColor);

    }
}