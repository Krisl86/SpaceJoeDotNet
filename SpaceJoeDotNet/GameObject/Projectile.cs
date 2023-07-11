using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;
using System;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject;

class Projectile : BaseSpaceJoeGameObject, IProjectile
{
    public Projectile(ICanShoot owner, ProjectileType projectileType,
            Vector2 position, Vector2 direction, int damage)
    {
        (Owner, ProjectileType, Position, Direction, Damage) = (owner, projectileType, position, direction, damage);
    }

    public ICanShoot Owner { get; set; }
    public ProjectileType ProjectileType { get; set; }
    public int Damage { get; set; }
    public int HitPoints { get; set; }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public override void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}