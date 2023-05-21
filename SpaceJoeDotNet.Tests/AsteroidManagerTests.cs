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

        [Fact]
        public void UpdateAsteroids_ShouldRemoveOffscreenAsteroids()
        {
            var am = new AsteroidManager();
            for (int i = 0; i < 30; i++)
                am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 0)) { HitPoints = 100 });

            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 800)) { HitPoints = 100 });
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 550)) { HitPoints = 100 });
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 399)) { HitPoints = 100 });
            am.Asteroids.Add(new Asteroid(AsteroidType.Medium, new Vector2(0, 400)) { HitPoints = 100 });
            am.UpdateAsteroids(new GameTime(), 400);

            Assert.Equal(32, am.Asteroids.Count);
        }
    }
}
