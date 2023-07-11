using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using System;

namespace SpaceJoeDotNet.GameObject
{


    class Asteroid : BaseSpaceJoeGameObject, IAsteroid
    {
        public Asteroid(AsteroidType asteroidType, Vector2 position)
        {
            (AsteroidType, Position) = (asteroidType, position);
        }

        public AsteroidType AsteroidType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int HitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScoreReward { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
