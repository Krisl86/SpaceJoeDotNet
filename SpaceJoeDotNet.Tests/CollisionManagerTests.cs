using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using Xunit;
using static System.Net.WebRequestMethods;

namespace SpaceJoeDotNet.Tests
{
    public class CollisionManagerTests
    {
        [Fact]
        public void CheckCollisions_ShouldReturnTrueForCollidingObjects()
        {
            var cm = new CollisionManager();
            var a1 = new Asteroid(AsteroidType.Medium, new Vector2(10, 20)) { Width = 100, Height = 100 };
            var a2 = new Asteroid(AsteroidType.Medium, new Vector2(30, 40)) { Width = 100, Height = 100 };
            var act = cm.CheckCollisions(a1, a2);
            Assert.True(act);
        }

        [Fact]
        public void CheckCollisions_ShouldReturnFalseForNonCollidingObjects()
        {
            var cm = new CollisionManager();
            var a1 = new Asteroid(AsteroidType.Medium, new Vector2(100, 2000)) { Width = 100, Height = 100 };
            var a2 = new Asteroid(AsteroidType.Medium, new Vector2(30, 40)) { Width = 100, Height = 100 };
            var act = cm.CheckCollisions(a1, a2);
            Assert.False(act);
        }

        [Fact]
        public void Collide_ShouldNotCollideProjectileWithOwner()
        {
            var cm = new CollisionManager();
            var pm = new DummyProjectileManager();
            var player = new Player(pm, new Vector2(0, 0))
                { HitPoints = 100, Width = 100, Height = 100 };

            var projectile = new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, 0), 100) 
                { HitPoints = 100, Width = 100, Height = 100 };

            cm.Collide(
                player,
                new List<Asteroid>(), 
                new List<Projectile>()
                {
                    projectile
                }, 
                new List<Alien>());

            Assert.True(player.HitPoints == 100 && projectile.HitPoints == 100);
        }

        [Fact]
        public void Collide_AlienProjectilesShouldNotCollideWithAsteroids()
        {
            var cm = new CollisionManager();
            var pm = new DummyProjectileManager();
            var player = new Player(pm, new Vector2(-2000, -2000));
            var alien = new Alien(pm, new Vector2(-5000, -5000));

            var projectile = new Projectile(alien, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, 0), 100)
            { HitPoints = 100, Width = 100, Height = 100 };

            var asteroid = new Asteroid(AsteroidType.Medium, new Vector2(0, 0))
            { HitPoints = 100, Width = 100, Height = 100 };

            cm.Collide(
                player,
                new List<Asteroid>() { asteroid },
                new List<Projectile>() { projectile },
                new List<Alien>());

            Assert.True(projectile.HitPoints == 100 && asteroid.HitPoints == 100);
        }
    }
}
