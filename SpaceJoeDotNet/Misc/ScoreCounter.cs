using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Utils
{
    static class ScoreCounter
    {
        public static void CountScoreFor(Player player, Asteroid asteroid)
        {
            switch (asteroid.AsteroidType)
            {
                case AsteroidType.Small: player.Score += 50; break;
                case AsteroidType.Medium: player.Score += 100; break;
                case AsteroidType.Large: player.Score += 150; break;
            }
        }
    }
}
