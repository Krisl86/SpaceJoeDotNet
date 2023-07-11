using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameManager
{

    class AlienManager : IAlienManager
    {
        const int SpawnMaxRand = 1000;
        const int SpawnRandLimit = 997;
        const int ShootMaxRand = 1000;
        const int ShootRandLimit = 970;

        Random __rand = new();

        public List<IAlien> Aliens { get; } = new();

        public void RandomlyGenerateAlien(int windowWidth, IProjectileManager projectileManager)
        {
            int x = __rand.Next(0, windowWidth);
            int y = -100;

            if (__rand.Next(0, SpawnMaxRand) > SpawnRandLimit)
                AddAlien(new Vector2(x, y), projectileManager);
        }

        public void RandomlyShoot(IBaseSpaceJoeGameObject target, int windowHeight)
        {
            foreach (var alien in Aliens.Where(a => a.Position.Y > 0 && a.Position.Y < windowHeight))
            {
                if (__rand.Next(0, ShootMaxRand) > ShootRandLimit)
                    alien.Shoot(target.Position - alien.Position);
            }
        }

        public void AddAlien(Vector2 position, IProjectileManager projectileManager)
            => Aliens.Add(Factory.NewAlien(position, projectileManager));

        public void DrawAliens(SpriteBatch spriteBatch)
            => Aliens.ForEach(a => a.Draw(spriteBatch));

        public void UpdateAliens(GameTime gameTime, int windowWidth, int windowHeight)
        {
            if (Aliens.Count > 15)
                Aliens.RemoveAll(a => a.Position.Y > windowHeight + 100);

            Aliens.RemoveAll(a => a.HitPoints <= 0);

            foreach (var alien in Aliens)
                alien.Update(gameTime);
        }

        public void Reset()
        {
            Aliens.Clear();
        }
    }
}
