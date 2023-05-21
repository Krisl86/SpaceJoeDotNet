using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
