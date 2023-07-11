using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using System;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{

    class AsteroidManager : IAsteroidManager
    {
        const int MaxRnd = 1000;
        const int MinRndLimit = 930;
        const int DefaultRndLimit = 990;

        int _rndLimit = DefaultRndLimit;
        Random __rand = new();

        public List<IAsteroid> Asteroids { get; } = new();

        public void RandomlyGenerateAsteroid(int windowWidth)
        {
            int x = __rand.Next(0, windowWidth);
            int y = -100;
            var asteroidType = (AsteroidType)__rand.Next(0, 3);

            if (__rand.Next(0, MaxRnd) > _rndLimit)
            {
                AddAsteroid(asteroidType, new Vector2(x, y));
                if (_rndLimit > MinRndLimit)
                    _rndLimit--;
            }
        }

        public void AddAsteroid(AsteroidType asteroidType, Vector2 position)
            => Asteroids.Add(Factory.NewAsteroid(asteroidType, position));

        public void DrawAsteroids(SpriteBatch spriteBatch)
            => Asteroids.ForEach(a => a.Draw(spriteBatch));

        public void UpdateAsteroids(GameTime gameTime, int windowHeight)
        {
            if (Asteroids.Count > 30)
                Asteroids.RemoveAll(a => a.Position.Y > windowHeight + 100);

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
