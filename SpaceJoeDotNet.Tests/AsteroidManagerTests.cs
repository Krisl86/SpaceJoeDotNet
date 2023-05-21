using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using Xunit;

namespace SpaceJoeDotNet.Tests
{
    public class AsteroidManagerTests
    {
        [Fact]
        public void UpdateAsteroids_ShouldRemoveDestroyedAsteroids()
        {
            var am = new AsteroidManager();
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 0)) { HitPoints = 1});
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 0)) { HitPoints = 10});
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 0)) { HitPoints = 0});
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 0)) { HitPoints = -4});
            am.UpdateAsteroids(new GameTime(), 400);

            Assert.Equal(2, am.Asteroids.Count);
        }
    }
}
