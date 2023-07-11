using SpaceJoeDotNet.GameManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.Misc.Interfaces
{
    interface ICanShoot
    {
        void Shoot(Vector2 direction);
        IProjectileManager ProjectileManager { get; set; }
    }
}
