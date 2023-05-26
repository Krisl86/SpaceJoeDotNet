using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using Xunit;

namespace SpaceJoeDotNet.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void TakeDamage_ShouldDepleteShieldFirst()
        {
            var player = new Player(new DummyProjectileManager(), new Vector2(0, 0))
            {
                HitPoints = 100,
                Shield = new(100, 500, 500)
            };

            player.TakeDamage(101);
            Assert.Equal(99, player.HitPoints);
            Assert.Equal(0, player.Shield.HitPoints);
        }
    }
}
