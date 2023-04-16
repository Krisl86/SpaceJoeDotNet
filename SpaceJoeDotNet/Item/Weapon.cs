using System.Numerics;
using SpaceJoeDotNet.GameObject;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Item;

class Weapon : Item
{
    readonly int _heatLimit;
    readonly float _cooldownTime;
    readonly ProjectileType _projectileType;
    readonly int _damage;

    public Weapon(string name, string shortName, string description, int price, int heatLimit, float cooldownTime,
        ProjectileType projectileType, int damage)
        : base(name, shortName, description, price)
    {
        _heatLimit = heatLimit;
        _cooldownTime = cooldownTime;
        _projectileType = projectileType;
        _damage = damage;
    }

    public void Shoot(Vector2 startPosition) => Projectile.Manager.AddProjectile(_projectileType, startPosition, _damage);
}