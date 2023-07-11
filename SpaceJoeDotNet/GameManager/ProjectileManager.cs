using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;
using System;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{

    class ProjectileManager : IProjectileManager
    {
        public List<IProjectile> Projectiles { get; } = new List<IProjectile>();

        public void AddProjectile(ICanShoot owner, ProjectileType projectileType, Vector2 position, Vector2 direction, int damage)
            => Projectiles.Add(Factory.NewProjectile(owner, projectileType, position, direction, damage));

        public void DrawProjectiles(SpriteBatch spriteBatch)
            => Projectiles.ForEach(p => p.Draw(spriteBatch));

        public void UpdateProjectiles(GameTime gameTime, int windowWidth, int windowHeight)
        {
            if (Projectiles.Count > 30)
                Projectiles.RemoveAll(p => p.Position.Y < 0 || p.Position.Y > windowHeight 
                || p.Position.X < 0 || p.Position.X > windowWidth);

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
