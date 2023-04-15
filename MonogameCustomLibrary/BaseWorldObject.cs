using Microsoft.Xna.Framework;

namespace MonogameCustom
{
    public abstract class BaseWorldObject
    {
        protected BaseWorldObject(Vector2 position)
        {
            (this.position) = (position);
        }

        protected Vector2 position;
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public float X { get => position.X; set => position.X = value; }
        public float Y { get => position.Y; set => position.Y = value; }

        public int Speed { get; set; }

        public abstract void Update(GameTime gameTime);
    }
}
