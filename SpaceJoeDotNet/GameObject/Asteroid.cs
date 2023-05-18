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
    }

    internal class Asteroid : GameObjectBase
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
                int speed, damage, hitPoints;

                switch (asteroidType)
                {
                    case AsteroidType.Small:
                        texture = Textures["asteroidSmall"];
                        speed = 600;
                        damage = 100;
                        hitPoints = 100;
                        break;
                    case AsteroidType.Medium:
                        texture = Textures["asteroidMedium"];
                        speed = 450;
                        damage = 175;
                        hitPoints = 150;
                        break;
                    case AsteroidType.Large:
                        texture = Textures["asteroidLarge"];
                        speed = 350;
                        damage = 260;
                        hitPoints = 200;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(asteroidType), asteroidType, null);
                }

                Asteroids.Add(new Asteroid(texture, new Vector2(x, -100), damage, hitPoints, speed));
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
                if (_rnd.Next(0, _maxRnd) > _rndLimit)
                {
                    GenerateAsteroid(asteroidType);
                    if (_rndLimit > _minRndLimit)
                        _rndLimit--;
                }
            }
        }

        public static IAsteroidManager Manager { get; } = new AsteroidManager();

        public Asteroid(Texture2D texture, Vector2 position, int damage, int hitPoints, int speed)
            : base(texture, position)
        {
            Damage = damage;
            HitPoints = hitPoints;
            Speed = speed;
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
