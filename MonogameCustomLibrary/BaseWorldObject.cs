using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameCustomLibrary
{
    public abstract class BaseWorldObject
    {
        protected BaseWorldObject(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            _position = position;
            Width = texture.Width;
            Height = texture.Height;
        }

        public Texture2D Texture { get; init; }

        public int Width { get; }
        public int Height { get; }
        
        Vector2 _position;
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public float X { get => _position.X; set => _position.X = value; }
        public float Y { get => _position.Y; set => _position.Y = value; }

        public int Speed { get; set; }

        public bool Collided { get; set; }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
