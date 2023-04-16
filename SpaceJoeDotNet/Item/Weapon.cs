using System.Numerics;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Item;

class Weapon : Item
{
    readonly int _heatLimit;
    readonly float _cooldownTime;
    readonly ProjectileType _projectileType;

    public Weapon(string name, string shortName, string description, int price, int heatLimit, float cooldownTime,
        ProjectileType projectileType)
        : base(name, shortName, description, price)
    {
        _heatLimit = heatLimit;
        _cooldownTime = cooldownTime;
        _projectileType = projectileType;
    }

    public void Shoot(Vector2 startPosition) => Projectile.Manager.AddProjectile(_projectileType, startPosition);
}