using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{
    interface IAsteroidManager
    {
        List<Asteroid> Asteroids { get; }
        Dictionary<string, Texture2D> Textures { get; }

        void AddAsteroid(AsteroidType asteroidType, Vector2 position);
        void DrawAsteroids(SpriteBatch spriteBatch);
        void RandomlyGenerateAsteroid(int windowWidth);
        void Reset();
        void UpdateAsteroids(GameTime gameTime, int windowHeight);
    }

    class AsteroidManager : IAsteroidManager
    {
        const int MaxRnd = 1000;
        const int MinRndLimit = 900;
        const int DefaultRndLimit = 990;

        int _rndLimit = DefaultRndLimit;
        Random _rnd = new();

        public List<Asteroid> Asteroids { get; } = new();

        public Dictionary<string, Texture2D> Textures { get; } = new();

        public void RandomlyGenerateAsteroid(int windowWidth)
        {
            int x = _rnd.Next(0, windowWidth);
            int y = -100;
            var asteroidType = (AsteroidType)_rnd.Next(0, 3);

            if (_rnd.Next(0, MaxRnd) > _rndLimit)
            {
                AddAsteroid(asteroidType, new Vector2(x, y));
                if (_rndLimit > MinRndLimit)
                    _rndLimit--;
            }
        }

        public void AddAsteroid(AsteroidType asteroidType, Vector2 position)
        {
            Texture2D texture = asteroidType switch
            {
                AsteroidType.Small => Textures["asteroidSmall"],
                AsteroidType.Medium => Textures["asteroidMedium"],
                AsteroidType.Large => Textures["asteroidLarge"],
                _ => throw new ArgumentOutOfRangeException(nameof(asteroidType), asteroidType, null),
            };

            Asteroids.Add(new Asteroid(asteroidType, position) { Texture = texture });
        }

        public void DrawAsteroids(SpriteBatch spriteBatch)
            => Asteroids.ForEach(a => a.Draw(spriteBatch));

        public void UpdateAsteroids(GameTime gameTime, int windowHeight)
        {
            if (Asteroids.Count > 30)
                Asteroids.RemoveAll(a => a.Y > windowHeight + 100);

            Asteroids.RemoveAll(a => a.HitPoints <= 0);

            foreach (var asteroid in Asteroids)
                asteroid.Update(gameTime);
        }

        public void Reset()
        {
            Asteroids.Clear();
            _rndLimit = DefaultRndLimit;
        }
    }
}
