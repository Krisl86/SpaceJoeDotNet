using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            if (Projectiles.Count > 30)
                Projectiles.RemoveAll(p => p.Y < 0);

            Projectiles.RemoveAll(p => p.HitPoints <= 0);

            foreach (var projectile in Projectiles)
                projectile.Update(gameTime);
        }

        public void Reset()
        {
            Projectiles.Clear();
        }
    }
}
