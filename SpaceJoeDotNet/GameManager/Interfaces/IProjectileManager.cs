using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager.Interfaces
{
    interface IProjectileManager : IResetable
    {
        List<IProjectile> Projectiles { get; }

        void AddProjectile(ICanShoot owner, ProjectileType projectileType, Vector2 position, Vector2 direction, int damage);
        void DrawProjectiles(SpriteBatch spriteBatch);
        void UpdateProjectiles(GameTime gameTime, int windowWidth, int windowHeight);
    }
}
