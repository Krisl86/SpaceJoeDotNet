using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Item;
using System;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject
{
    class Alien : BaseSpaceJoeGameObject, IAlien
    {
        public Alien(Vector2 position, IProjectileManager projectileManager)
        {
            (Position, ProjectileManager) = (position, projectileManager);
        }

        public int HitPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScoreReward { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IProjectileManager ProjectileManager { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Shoot(Vector2 direction)
        {
            throw new NotImplementedException();
        }

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
