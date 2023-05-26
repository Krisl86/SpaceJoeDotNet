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
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 0), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 0), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 0), 10) { HitPoints = -200 });
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 0), 10) { HitPoints = 0 });
            pm.UpdateProjectiles(new GameTime());

            Assert.Equal(2, pm.Projectiles.Count);
        }

        [Fact]
        public void UpdateProjectiles_ShouldRemoveOffscreenProjectiles()
        {
            var pm = new ProjectileManager();
            for (int i = 0; i < 30; i++)
                pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 0), 10) { HitPoints = 1 });

            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 100), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, 0), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, -50), 10) { HitPoints = 1 });
            pm.Projectiles.Add(new Projectile(ProjectileType.Default, new Vector2(0, -200), 10) { HitPoints = 1 });
            pm.UpdateProjectiles(new GameTime());

            Assert.Equal(32, pm.Projectiles.Count);
        }
    }
}
