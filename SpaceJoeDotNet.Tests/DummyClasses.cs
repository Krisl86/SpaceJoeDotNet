﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Tests
{
    class DummyProjectileManager : IProjectileManager
    {
        public List<Projectile> Projectiles { get; } = new();

        public Dictionary<string, Texture2D> Textures => throw new NotImplementedException();

        public void AddProjectile(ProjectileType projectileType, Vector2 position, int damage)
        {
            Projectiles.Add(new Projectile(projectileType, position, damage));
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void UpdateProjectiles(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
