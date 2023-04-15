using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameCustomLibrary
{
    public static class Extensions
    {
        public static SpriteBatch DrawSimple(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
        {
            spriteBatch.Draw(texture, position, Color.White);
            return spriteBatch;
        }
        public static SpriteBatch DrawSimple(this SpriteBatch spriteBatch, Texture2D texture, float x, float y)
            => spriteBatch.DrawSimple(texture, new Vector2(x, y));

        public static SpriteBatch DrawCentered(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
        {
            spriteBatch.DrawSimple(texture, texture.Centered(position.X, position.Y));
            return spriteBatch;
        }
        public static SpriteBatch DrawCentered(this SpriteBatch spriteBatch, Texture2D texture, float x, float y)
            => spriteBatch.DrawCentered(texture, new Vector2(x, y)) ;

        public static SpriteBatch DrawStringCentered(this SpriteBatch spriteBatch, bool centerVertically, SpriteFont spriteFont, string text,
            Vector2 position, Color color)
        {
            var textSize = spriteFont.MeasureString(text);
            float newX = position.X - textSize.X / 2;
            float newY = position.Y;

            if (centerVertically)
                newY = position.Y - textSize.Y / 2;

            spriteBatch.DrawString(spriteFont, text, new Vector2(newX, newY), color);
            return spriteBatch;
        }
        public static SpriteBatch DrawStringCentered(this SpriteBatch spriteBatch, bool centerVertically, SpriteFont spriteFont, string text,
            float x, float y, Color color)
            => DrawStringCentered(spriteBatch, centerVertically, spriteFont, text, new Vector2(x, y), color);


        public static Vector2 Centered(this Texture2D texture, Vector2 position)
            => new(position.X - texture.Width / 2, position.Y - texture.Height / 2);
        public static Vector2 Centered(this Texture2D texture, float x, float y)
            => texture.Centered(new Vector2(x, y));

    }
}
