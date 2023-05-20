using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using System;

namespace SpaceJoeDotNet.GameObject
{

    enum AsteroidType
    {
        Small, Medium, Large
    }


    internal class Asteroid : GameObjectBase
    {
        public Asteroid(Texture2D texture, AsteroidType asteroidType, Vector2 position) : base(position)
        {
            Texture = texture;
            AsteroidType = asteroidType;
            AssignPropertiesByType(AsteroidType);
        }

        public AsteroidType AsteroidType { get; }

        public override void Draw(SpriteBatch spriteBatch)
            => spriteBatch.DrawCentered(Texture, Position);

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += Speed * dt;
        }

        void AssignPropertiesByType(AsteroidType type)
        {
            switch (type)
            {
                case AsteroidType.Small:
                    Speed = 600;
                    Damage = 100;
                    HitPoints = 100;
                    break;
                case AsteroidType.Medium:
                    Speed = 450;
                    Damage = 175;
                    HitPoints = 150;
                    break;
                case AsteroidType.Large:
                    Speed = 350;
                    Damage = 260;
                    HitPoints = 200;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
