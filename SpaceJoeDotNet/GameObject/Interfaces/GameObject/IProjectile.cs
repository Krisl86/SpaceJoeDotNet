using SpaceJoeDotNet.Enums;
using SpaceJoeDotNet.Misc.Interfaces;
using SpaceJoeDotNet.Misc.Interfaces.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject.Interfaces.GameObject
{
    interface IProjectile : IBaseSpaceJoeGameObject, ICanDealDamage, ICanTakeDamage, ICollidableGameObject
    {
        ICanShoot Owner { get; set; }
        ProjectileType ProjectileType { get; set; }
    }
}
