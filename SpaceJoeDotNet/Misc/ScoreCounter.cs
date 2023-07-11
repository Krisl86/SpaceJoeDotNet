using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces.Score;

namespace SpaceJoeDotNet.Utils
{
    static class ScoreCounter
    {
        public static void CountScoreFor(IPlayer player, IHasScoreReward obj)
            => player.Score += obj.ScoreReward;
    }
}
