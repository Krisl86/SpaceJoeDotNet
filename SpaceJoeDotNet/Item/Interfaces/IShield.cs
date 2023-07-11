using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;
using SpaceJoeDotNet.Misc.Interfaces.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.Item.Interfaces
{
    interface IShield : IGameObject, ICanTakeDamage, IResetable
    {
        float DelayCounter { get; }
        int MaxHitPoints { get; set; }
        float RecoveryDelay { get; set; }
        float RecoveryTime { get; set; }
    }
}
