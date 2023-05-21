using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{
    interface IProjectileManager
    {
        List<Projectile> Projectiles { get; }
        Dictionary<string, Texture2D> Textures { get; }

        void AddProjectile(ProjectileType projectileType, Vector2 position, int damage);
        void DrawProjectiles(SpriteBatch spriteBatch);
        void Reset();
        void UpdateProjectiles(GameTime gameTime);
    }

    class ProjectileManager : IProjectileManager
    {
        public List<Projectile> Projectiles { get; } = new();
        public Dictionary<string, Texture2D> Textures { get; } = new();

        public void AddProjectile(ProjectileType projectileType, Vector2 position, int damage)
        {
            Texture2D texture = projectileType switch
            {
                ProjectileType.Default => Textures["projectileDefault"],
                ProjectileType.Slow => Textures["projectileSlow"],
                ProjectileType.Fast => Textures["projectileFast"],
                _ => throw new ArgumentOutOfRangeException(nameof(projectileType), projectileType, null),
            };

            Projectiles.Add(new Projectile(projectileType, position, damage) { Texture = texture });
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
            => Projectiles.ForEach(p => p.Draw(spriteBatch));

        public void UpdateProjectiles(GameTime gameTime)
        {
            for (var i = 0; i < Projectiles.Count; i++)
            {
                if ((Projectiles.Count > 30 && Projectiles[i].Y < 0)
                    || Projectiles[i].HitPoints <= 0) // remove off-screen projectiles every once in a while
                {
                    Projectiles.RemoveAt(i);
                    return;
                }
                Projectiles[i].Update(gameTime);
            }
        }

        public void Reset()
        {
            Projectiles.Clear();
        }
    }
}
