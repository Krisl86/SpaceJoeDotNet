namespace SpaceJoeDotNet.GameObject
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    namespace SpaceJoeDotNet.GameObject
    {
        public abstract class GameObjectBase
        {
            protected GameObjectBase(Vector2 position)
            {
                _position = position;
            }

            Texture2D? texture;
            public Texture2D? Texture
            {
                get => texture;
                set
                {
                    if (value is not null)
                    {
                        texture = value;
                        Width = texture.Width;
                        Height = texture.Height;
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

            public abstract void Update(GameTime gameTime);
            public abstract void Draw(SpriteBatch spriteBatch);
        }
    }

}
