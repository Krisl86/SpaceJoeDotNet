using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;

namespace SpaceJoeDotNet.Tests.Dummy
{
    class DummyProjectileManager : IProjectileManager
    {
        public List<IProjectile> Projectiles { get; } = new();

        public Dictionary<string, Texture2D> Textures => throw new NotImplementedException();

        public void AddProjectile(ICanShoot owner, ProjectileType projectileType, Vector2 position, Vector2 direction, int damage)
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
