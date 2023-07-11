using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Item.Interfaces;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Item;

class Weapon : IWeapon
{
    float _timeSinceCooldown;

    public Weapon(IProjectileManager projectileManager, ProjectileType projectileType,
        int damage, float cooldownTime, int heatLimit)
    {
        ProjectileType = projectileType;
        Damage = damage;
        CooldownTime = cooldownTime;
        HeatLimit = heatLimit;
        ProjectileManager = projectileManager;
    }

    public int CurrentHeat { get; set; }
    public int HeatLimit { get; set; }
    public float CooldownTime { get; set; }
    public int Damage { get; set; }
    internal ProjectileType ProjectileType { get; set; }
    public IProjectileManager ProjectileManager { get; set; }
    public Vector2 Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Shoot(Vector2 direction)
    {
        if (CurrentHeat < HeatLimit)
        {
            ProjectileManager.AddProjectile(this, ProjectileType, Position, direction, Damage);
            CurrentHeat++;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (CurrentHeat > 0)
        {
            _timeSinceCooldown += gameTime.DeltaTime();
            if (_timeSinceCooldown >= CooldownTime)
            {
                CurrentHeat--;
                _timeSinceCooldown = 0;
            }
        }
    }

    public void Reset()
    {
        CurrentHeat = 0;
    }
}