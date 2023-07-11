using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.Misc.Interfaces.Damage
{
    interface ICanTakeDamage
    {
        int HitPoints { get; set; }
        void TakeDamage(int damage);
    }
}
