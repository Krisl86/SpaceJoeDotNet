using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Tests
{
    class DummyProjectileManager : IProjectileManager
    {
        public List<Projectile> Projectiles { get; } = new();

        public Dictionary<string, Texture2D> Textures => throw new NotImplementedException();

        public void AddProjectile(GameObjectBase owner, ProjectileType projectileType, Vector2 position, Vector2 direction, int damage)
        {
            Projectiles.Add(new Projectile(owner, projectileType, position, direction, damage));
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void UpdateProjectiles(GameTime gameTime, int windowWidth, int windowHeight)
        {
            throw new NotImplementedException();
        }
    }
}
