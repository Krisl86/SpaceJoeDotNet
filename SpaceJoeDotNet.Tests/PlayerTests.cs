using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Tests.Dummy;
using SpaceJoeDotNet.Utils;
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
            };

            player.TakeDamage(151);
            Assert.Equal(99, player.HitPoints);
            Assert.Equal(0, player.Shield.HitPoints);
        }

        [Fact]
        public void Score_ShouldAddCorrectScoreByType()
        {
            var dpm = new DummyProjectileManager();
            var player = new Player(dpm, new Vector2(0, 0))
            {
                Score = 0
            };

            var smallAsteroid = new Asteroid(AsteroidType.Small, new Vector2(0, 0));
            var mediumAsteroid = new Asteroid(AsteroidType.Medium, new Vector2(0, 0));
            var largeAsteroid = new Asteroid(AsteroidType.Large, new Vector2(0, 0));
            var alien = new Alien(dpm, new Vector2(0, 0));

            ScoreCounter.CountScoreFor(player, smallAsteroid);
            ScoreCounter.CountScoreFor(player, mediumAsteroid);
            ScoreCounter.CountScoreFor(player, largeAsteroid);
            ScoreCounter.CountScoreFor(player, alien);

            Assert.True(player.Score == 550);
        }
    }
}
