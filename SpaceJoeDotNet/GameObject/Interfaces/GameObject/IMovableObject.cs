using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject.Interfaces.GameObject
{
    interface IMovableObject
    {
        int Speed { get; set; }
        Vector2 Direction { get; set; }
    }
}
