using System;
using System.Numerics;
using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Item;

class Weapon : Item
{
    readonly float _cooldownTime;
    readonly ProjectileType _projectileType;
    readonly int _damage;

    float _totalCooldownTime;
    float _timeSinceCooldown;
    
    public Weapon(string name, string shortName, string description, int price, int heatLimit, float cooldownTime,
        ProjectileType projectileType, int damage)
        : base(name, shortName, description, price)
    {
        HeatLimit = heatLimit;
        _cooldownTime = cooldownTime;
        _projectileType = projectileType;
        _damage = damage;
    }

    public int CurrentHeat { get; private set; }
    public int HeatLimit { get; }
    
    public void Shoot(Vector2 startPosition)
    {
        if (CurrentHeat < HeatLimit)
        {
            Projectile.Manager.AddProjectile(_projectileType, startPosition, _damage);
            _totalCooldownTime += _cooldownTime;
            CurrentHeat++;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (CurrentHeat > 0)
        {
            _timeSinceCooldown += gameTime.DeltaTime();
            if (_timeSinceCooldown >= _cooldownTime)
            {
                CurrentHeat--;
                _timeSinceCooldown = 0;
            }
        }
    }
}