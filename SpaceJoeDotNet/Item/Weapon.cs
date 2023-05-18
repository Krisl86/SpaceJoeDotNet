using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Item;

class Weapon
{
    float _timeSinceCooldown;
    
    public Weapon(ProjectileType projectileType, int damage, float cooldownTime, int heatLimit)
    {
        ProjectileType = projectileType;
        Damage = damage;
        CooldownTime = cooldownTime;
        HeatLimit = heatLimit;
    }

    public int CurrentHeat { get; set; }
    public int HeatLimit { get; }
    public float CooldownTime { get; set; }
    public int Damage { get; set; }
    internal ProjectileType ProjectileType { get; set; }

    public void Shoot(Vector2 startPosition)
    {
        if (CurrentHeat < HeatLimit)
        {
            Projectile.Manager.AddProjectile(ProjectileType, startPosition, Damage);
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
}