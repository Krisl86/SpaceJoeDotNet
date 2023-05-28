namespace SpaceJoeDotNet.GameObject
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MonogameCustomLibrary;

    namespace SpaceJoeDotNet.GameObject
    {
        public abstract class GameObjectBase
        {
            protected GameObjectBase(Vector2 position)
            {
                _position = position;
            }

            public Texture2D? _texture;
            public Texture2D? Texture
            {
                get => _texture;
                set
                {
                    if (value is not null)
                    {
                        _texture = value;
                        Width = value.Width;
                        Height = value.Height;
                    }
                }
            }

            Vector2 _position;
            public Vector2 Position
            {
                get => _position;
                set => _position = value;
            }

            public float X { get => _position.X; set => _position.X = value; }
            public float Y { get => _position.Y; set => _position.Y = value; }

            public int Width { get; set; } = 1;
            public int Height { get; set; } = 1;

            public int Speed { get; set; }
            public int Damage { get; protected set; }
            public int HitPoints { get; set; }

            public virtual void TakeDamage(int damage) => HitPoints -= damage;

            public virtual void Draw(SpriteBatch spriteBatch)
            {
                if (Texture is not null)
                    spriteBatch.DrawCentered(Texture, Position);
            }

            public abstract void Update(GameTime gameTime);
        }
    }

}
