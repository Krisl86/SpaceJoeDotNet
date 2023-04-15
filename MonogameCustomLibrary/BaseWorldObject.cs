using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameCustomLibrary
{
    public abstract class BaseWorldObject
    {
        protected BaseWorldObject(Vector2 position)
        {
            _position = position;
        }

        public Texture2D? Texture { get; init; }

        public int Width { get; set; }
        public int Height { get; set; }
        
        Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public float X { get => _position.X; set => _position.X = value; }
        public float Y { get => _position.Y; set => _position.Y = value; }

        public int Speed { get; set; }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
