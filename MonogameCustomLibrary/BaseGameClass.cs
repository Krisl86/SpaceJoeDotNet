using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameCustom
{
    public abstract class BaseGameClass : Game
    {
        protected SpriteBatch spriteBatch;

        protected BaseGameClass()
        {
            Instance = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public GraphicsDeviceManager Graphics { get; }
        public static Game Instance { get; private set; }

    }
}
