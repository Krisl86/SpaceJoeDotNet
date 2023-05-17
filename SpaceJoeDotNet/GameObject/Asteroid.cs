using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject
{

    enum AsteroidType
    {
        Small, Medium, Large
    }

    interface IAsteroidManager
    {
        List<Asteroid> Asteroids { get; }
        Dictionary<string, Texture2D> Textures { get; }
        void RandomlyGenerateAsteroid();
        void GenerateAsteroid(AsteroidType asteroidType);
        void DrawAsteroids(SpriteBatch spriteBatch);
        void UpdateAsteroids(GameTime gameTime);
    }

    internal class Asteroid : BaseWorldObject
    {
        class AsteroidManager : IAsteroidManager
        {
            int _maxRnd = 1000;
            int _rndLimit = 990;
            int _minRndLimit = 900;
            Random _rnd = new();

            public List<Asteroid> Asteroids { get; } = new();

            public Dictionary<string, Texture2D> Textures { get; } = new();

            public void GenerateAsteroid(AsteroidType asteroidType)
            {
                int x = _rnd.Next(0, SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth);
                Texture2D texture;
                int speed;
                int damage;

                switch (asteroidType)
                {
                    case AsteroidType.Small:
                        texture = Textures["asteroidSmall"];
                        speed = 600;
                        damage = 100;
                        break;
                    case AsteroidType.Medium:
                        texture = Textures["asteroidMedium"];
                        speed = 450;
                        damage = 175;
                        break;
                    case AsteroidType.Large:
                        texture = Textures["asteroidLarge"];
                        speed = 350;
                        damage = 260;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(asteroidType), asteroidType, null);
                }

                Asteroids.Add(new Asteroid(texture, new Vector2(x, -100), damage) { Speed = speed });
            }

            public void DrawAsteroids(SpriteBatch spriteBatch)
                => Asteroids.ForEach(a => a.Draw(spriteBatch));

            public void UpdateAsteroids(GameTime gameTime)
            {
                for (var i = 0; i < Asteroids.Count; i++)
                {
                    if ((Asteroids.Count > 30
                        && Asteroids[i].Y > SpaceJoeGame.Instance.Graphics.PreferredBackBufferHeight + 100)
                        || Asteroids[i].Collided) 
                    {
                        Asteroids.RemoveAt(i);
                        return;
                    }
                    
                    Asteroids[i].Update(gameTime);
                }
            }

            public void RandomlyGenerateAsteroid()
            {
                var asteroidType = (AsteroidType)_rnd.Next(0, 3);
                if (_rnd.Next(0, _maxRnd) > _rndLimit)
                {
                    GenerateAsteroid(asteroidType);
                    if (_rndLimit > _minRndLimit)
                        _rndLimit--;
                }
            }
        }

        public static IAsteroidManager Manager { get; } = new AsteroidManager();

        public int Damage { get; }

        public Asteroid(Texture2D texture, Vector2 position, int damage) : base(texture, position)
        {
            Damage = damage;   
        }

        public override void Draw(SpriteBatch spriteBatch)
            => spriteBatch.DrawCentered(Texture, Position);

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += Speed * dt;
        }
    }
}
