using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameCustomLibrary
{
    public abstract class BaseGameClass : Game
    {
        protected BaseGameClass()
        {
            Instance = this;
            Graphics = new(this);
            Content.RootDirectory = "Content";
        }

        public GraphicsDeviceManager Graphics { get; }
        public static Game? Instance { get; private set; }

        protected SpriteBatch? SpriteBatch { get; set; }
    }
}