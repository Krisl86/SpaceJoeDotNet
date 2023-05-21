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
    public class WeaponTests
    {
        [Fact]
        public void Shoot_ShouldNotAddProjectileWhenOverheated()
        {
            var pm = new DummyProjectileManager();
            var w = new Weapon(pm, ProjectileType.Default, 10, 100, 2);
            w.Shoot(new Vector2(0, 0));
            w.Shoot(new Vector2(0, 0));
            w.Shoot(new Vector2(0, 0));
            w.Shoot(new Vector2(0, 0));

            Assert.Equal(2, pm.Projectiles.Count);
        }
    }
}
