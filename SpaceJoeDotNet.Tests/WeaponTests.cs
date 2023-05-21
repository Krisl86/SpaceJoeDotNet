using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Item;
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
