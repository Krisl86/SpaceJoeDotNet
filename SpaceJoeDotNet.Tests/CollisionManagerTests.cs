using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using Xunit;
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
    }
}
