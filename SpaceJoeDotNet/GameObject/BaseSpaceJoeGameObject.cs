using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject.Interfaces;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;

namespace SpaceJoeDotNet.GameObject
    {
    public abstract class BaseSpaceJoeGameObject : IBaseSpaceJoeGameObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Speed { get; set; }
        public Vector2 Direction { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
                spriteBatch.DrawCentered(Texture, Position);
        }

        public abstract void Update(GameTime gameTime);
    }
}

