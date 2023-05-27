using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using Xunit;

namespace SpaceJoeDotNet.Tests
{
    public class ProjectileManagerTests
    {
        [Fact]
        public void UpdateProjectiles_ShouldRemoveDestroyedProjectiles()
        {
            var pm = new ProjectileManager();
            var player = new Player(pm, new Vector2(0, 0));

            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, -1), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, -1), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, -1), 10) { HitPoints = -200 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, -1), 10) { HitPoints = 0 });
            pm.UpdateProjectiles(new GameTime(), 100, 100);

            Assert.Equal(2, pm.Projectiles.Count);
        }

        [Fact]
        public void UpdateProjectiles_ShouldRemoveOffscreenProjectiles()
        {
            var pm = new ProjectileManager();
            var player = new Player(pm, new Vector2(0, 0));

            for (int i = 0; i < 30; i++)
                pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, -1), 10) { HitPoints = 1 });

            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 80), new Vector2(0, -1), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 0), new Vector2(0, -1), 10) { HitPoints = 1 });
            
            // Y
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, -50), new Vector2(0, -1), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, -200), new Vector2(0, -1), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(0, 150), new Vector2(0, -1), 10) { HitPoints = 1 });

            // X
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(1000, 10), new Vector2(0, -1), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(player, ProjectileType.Default, new Vector2(-100, 10), new Vector2(0, -1), 10) { HitPoints = 1 });
            
            pm.UpdateProjectiles(new GameTime(), 100, 100);

            Assert.Equal(32, pm.Projectiles.Count);
        }
    }
}
