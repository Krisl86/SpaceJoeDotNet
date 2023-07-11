using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject.Interfaces.GameObject
{
    interface IDrawableObject
    {
        Texture2D Texture { get; set; }
        void Draw(SpriteBatch spriteBatch);
    }
}
