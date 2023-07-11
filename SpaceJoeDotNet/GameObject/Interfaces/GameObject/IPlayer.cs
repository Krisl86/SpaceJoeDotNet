using SpaceJoeDotNet.Item.Interfaces;
using SpaceJoeDotNet.Misc.Interfaces;
using SpaceJoeDotNet.Misc.Interfaces.Damage;
using SpaceJoeDotNet.Misc.Interfaces.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject.Interfaces.GameObject
{
    interface IPlayer : IBaseSpaceJoeGameObject, ICanTakeDamage,
        ICanDealDamage, IResetable, ITracksScore, ICanShoot, ICollidableGameObject
    {
        IWeapon Weapon { get; set; }
        IShield Shield { get; set; }
    }
}
