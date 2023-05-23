using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonogameCustomLibrary
{
    public class SpriteAnimation
    {
        readonly List<Texture2D> _frames;
        readonly float _timeToUpdate;

        int _currentFrame = 0;
        float _timeElapsed;

        public SpriteAnimation(List<Texture2D> frames, int fps)
        {
            _frames = frames;
            _timeToUpdate = 1f / fps;
        }

        public bool Loop { get; set; } = true;

        public void Update(GameTime gameTime)
        {
            _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (_timeElapsed >= _timeToUpdate)
            {
                _timeElapsed = 0;

                if (_currentFrame < _frames.Count - 1)
                    _currentFrame++;

                else if (Loop)
                    _currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
            => spriteBatch.Draw(_frames[_currentFrame], position, Color.White);

        public void DrawCentered(SpriteBatch spriteBatch, Vector2 position)
            => spriteBatch.DrawCentered(_frames[_currentFrame], position);
    }
}