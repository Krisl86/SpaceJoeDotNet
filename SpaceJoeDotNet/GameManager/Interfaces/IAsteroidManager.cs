using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager.Interfaces
{
    interface IAsteroidManager : IResetable
    {
        List<IAsteroid> Asteroids { get; }

        void AddAsteroid(AsteroidType asteroidType, Vector2 position);
        void DrawAsteroids(SpriteBatch spriteBatch);
        void RandomlyGenerateAsteroid(int windowWidth);
        void UpdateAsteroids(GameTime gameTime, int windowHeight);
    }
}
