using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Item;

class Weapon
{
    float _timeSinceCooldown;
    IProjectileManager _manager;

    public Weapon(IProjectileManager projectileManager, ProjectileType projectileType,
        int damage, float cooldownTime, int heatLimit)
    {
        ProjectileType = projectileType;
        Damage = damage;
        CooldownTime = cooldownTime;
        HeatLimit = heatLimit;
        _manager = projectileManager;
    }

    public int CurrentHeat { get; set; }
    public int HeatLimit { get; set; }
    public float CooldownTime { get; set; }
    public int Damage { get; set; }
    internal ProjectileType ProjectileType { get; set; }

    public void Shoot(GameObjectBase projectileOwner, Vector2 startPosition, Vector2 direction)
    {
        if (CurrentHeat < HeatLimit)
        {
            _manager.AddProjectile(projectileOwner, ProjectileType, startPosition, direction, Damage);
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