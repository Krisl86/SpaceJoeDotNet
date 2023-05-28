using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameManager
{
    interface IAlienManager
    {
        List<Alien> Aliens { get; }
        Dictionary<string, Texture2D> Textures { get; }

        void RandomlyGenerateAlien(int windowWidth, IProjectileManager projectileManager);
        void RandomlyShoot(GameObjectBase target, int windowHeight);
        void AddAlien(Vector2 position, IProjectileManager projectileManager);
        void DrawAliens(SpriteBatch spriteBatch);
        void Reset();
        void UpdateAliens(GameTime gameTime, int windowWidth, int windowHeight);
    }

    class AlienManager : IAlienManager
    {
        const int SpawnMaxRand = 1000;
        const int SpawnRandLimit = 997;
        const int ShootMaxRand = 1000;
        const int ShootRandLimit = 970;

        Random __rand = new();

        public List<Alien> Aliens { get; } = new();

        public Dictionary<string, Texture2D> Textures { get; } = new();

        public void RandomlyGenerateAlien(int windowWidth, IProjectileManager projectileManager)
        {
            int x = __rand.Next(0, windowWidth);
            int y = -100;

            if (__rand.Next(0, SpawnMaxRand) > SpawnRandLimit)
                AddAlien(new Vector2(x, y), projectileManager);
        }

        public void RandomlyShoot(GameObjectBase target, int windowHeight)
        {
            foreach (var alien in Aliens.Where(a => a.Y > 0 && a.Y < windowHeight))
            {
                if (__rand.Next(0, ShootMaxRand) > ShootRandLimit)
                    alien.Shoot(target.Position - alien.Position);
            }
        }

        public void AddAlien(Vector2 position, IProjectileManager projectileManager)
            => Aliens.Add(new Alien(projectileManager, position) { Texture = Textures["alien"] });

        public void DrawAliens(SpriteBatch spriteBatch)
            => Aliens.ForEach(a => a.Draw(spriteBatch));

        public void UpdateAliens(GameTime gameTime, int windowWidth, int windowHeight)
        {
            if (Aliens.Count > 15)
                Aliens.RemoveAll(a => a.Y > windowHeight + 100);

            Aliens.RemoveAll(a => a.HitPoints <= 0);

            foreach (var alien in Aliens)
                alien.Update(gameTime, windowWidth);
        }

        public void Reset()
        {
            Aliens.Clear();
        }
    }
}
