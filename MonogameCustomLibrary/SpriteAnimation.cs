using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameCustom
{
    public class SpriteManager
    {
        public SpriteManager(Texture2D texture, int frames)
        {
            Texture = texture;
            int width = texture.Width / frames;
            Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
                Rectangles[i] = new Rectangle(i * width, 0, width, texture.Height);
        }

        protected Texture2D Texture { get; set; }
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Color Color { get; set; } = Color.White;
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; } = 0f;
        public float Scale { get; set; } = 1f;
        public SpriteEffects SpriteEffect { get; set; }
        protected Rectangle[] Rectangles { get; set; }
        protected int FrameIndex { get; set; } = 0;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Rectangles[FrameIndex], Color, Rotation, Origin, Scale, SpriteEffect, 0f);
        }
    }

    public class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        private float timeToUpdate; //default, you may have to change it
        public int FramesPerSecond { set { timeToUpdate = (1f / value); } }

        public SpriteAnimation(Texture2D Texture, int frames, int fps) : base(Texture, frames) 
        {
            FramesPerSecond = fps;
        }

        public bool IsLooping { get; set; } = true;

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (FrameIndex < Rectangles.Length - 1)
                    FrameIndex++;

                else if (IsLooping)
                    FrameIndex = 0;
            }
        }

        public void SetFrame(int frame) => FrameIndex = frame;
    }
}