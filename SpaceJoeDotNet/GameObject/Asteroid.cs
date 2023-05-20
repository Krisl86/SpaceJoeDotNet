using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Collision;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;

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
        void Reset();
    }

    internal class Asteroid : GameObjectBase
    {
        class AsteroidManager : IAsteroidManager
        {
            const int MaxRnd = 1000;
            const int MinRndLimit = 900;
            const int DefaultRndLimit = 990;

            int _rndLimit = DefaultRndLimit;
            Random _rnd = new();

            public List<Asteroid> Asteroids { get; } = new();

            public Dictionary<string, Texture2D> Textures { get; } = new();

            public void GenerateAsteroid(AsteroidType asteroidType)
            {
                int x = _rnd.Next(0, SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth);
                Texture2D texture;
                int speed, damage, hitPoints;
                AsteroidType type;

                switch (asteroidType)
                {
                    case AsteroidType.Small:
                        texture = Textures["asteroidSmall"];
                        speed = 600;
                        damage = 100;
                        hitPoints = 100;
                        type = AsteroidType.Small;
                        break;
                    case AsteroidType.Medium:
                        texture = Textures["asteroidMedium"];
                        speed = 450;
                        damage = 175;
                        hitPoints = 150;
                        type = AsteroidType.Medium;
                        break;
                    case AsteroidType.Large:
                        texture = Textures["asteroidLarge"];
                        speed = 350;
                        damage = 260;
                        hitPoints = 200;
                        type = AsteroidType.Large;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(asteroidType), asteroidType, null);
                }

                Asteroids.Add(new Asteroid(texture, new Vector2(x, -100), damage, hitPoints, speed, type));
            }

            public void DrawAsteroids(SpriteBatch spriteBatch)
                => Asteroids.ForEach(a => a.Draw(spriteBatch));

            public void UpdateAsteroids(GameTime gameTime)
            {
                for (var i = 0; i < Asteroids.Count; i++)
                {
                    if ((Asteroids.Count > 30
                        && Asteroids[i].Y > SpaceJoeGame.Instance.Graphics.PreferredBackBufferHeight + 100)
                        || Asteroids[i].HitPoints <= 0) 
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
                if (_rnd.Next(0, MaxRnd) > _rndLimit)
                {
                    GenerateAsteroid(asteroidType);
                    if (_rndLimit > MinRndLimit)
                        _rndLimit--;
                }
            }

            public void Reset()
            {
                Asteroids.Clear();
                _rndLimit = DefaultRndLimit;
            }
        }

        public static IAsteroidManager Manager { get; } = new AsteroidManager();
        public AsteroidType AsteroidType { get; }

        public Asteroid(Texture2D texture, Vector2 position, int damage, int hitPoints, 
            int speed, AsteroidType asteroidType) : base(texture, position)
        {
            Damage = damage;
            HitPoints = hitPoints;
            Speed = speed;
            AsteroidType = asteroidType;
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
