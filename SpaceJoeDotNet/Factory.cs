using Microsoft.Xna.Framework;
using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Item;
using SpaceJoeDotNet.Item.Interfaces;
using SpaceJoeDotNet.Misc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet
{
    static class Factory
    {
        public static IProjectile NewProjectile(ICanShoot owner, ProjectileType projectileType,
            Vector2 position, Vector2 direction, int damage) 
            => new Projectile(owner, projectileType, position, direction, damage);

        public static IAsteroid NewAsteroid(AsteroidType asteroidType, Vector2 position)
            => new Asteroid(asteroidType, position);

        public static IAlien NewAlien(Vector2 position, IProjectileManager projectileManager) 
            => new Alien(position, projectileManager);

        public static IWeapon NewWeapon(ProjectileType projectileType, int damage, int cooldownTime, int heatLimit) 
            => new Weapon(SingleInstanceProjectileManager(), projectileType, damage, cooldownTime, heatLimit);

        public static IShield NewShield(int maxHitPoints, float recoveryDelay, float recoveryTime)
            => new Shield(maxHitPoints, recoveryDelay, recoveryTime);



        static IProjectileManager _projectileManager = new ProjectileManager();
        public static IProjectileManager SingleInstanceProjectileManager()
            => _projectileManager ??= new ProjectileManager();

        static IPlayer _player = new Player(SingleInstanceProjectileManager(),
            NewWeapon(ProjectileType.Default, 10, 10, 10),
            NewShield(100, 10, 10));
        public static IPlayer SingleInstancePlayer()
            => _player ??= new Player(SingleInstanceProjectileManager(),
            NewWeapon(ProjectileType.Default, 10, 10, 10),
            NewShield(100, 10, 10));
    }
}
