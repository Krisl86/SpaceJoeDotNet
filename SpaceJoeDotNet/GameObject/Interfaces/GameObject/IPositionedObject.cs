using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject.Interfaces.GameObject
{
    interface IPositionedObject
    {
        Vector2 Position { get; set; }
    }
}
