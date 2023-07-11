using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.Misc.Interfaces.Damage;
using SpaceJoeDotNet.Misc.Interfaces.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject.Interfaces.GameObject
{
    interface IAsteroid : IBaseSpaceJoeGameObject, ICanDealDamage,
        ICanTakeDamage, IHasScoreReward, ICollidableGameObject
    {
        AsteroidType AsteroidType { get; set; }
    }
}
