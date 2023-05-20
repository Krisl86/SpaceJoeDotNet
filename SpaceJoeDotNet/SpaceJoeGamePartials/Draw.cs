using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        protected override void Draw(GameTime gameTime)
        {
            if (_spriteBatch is null)
                throw new NullReferenceException("SpriteBatch is null!");

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (_gameState == GameState.InGame)
            {
                _background.Draw(_spriteBatch);

                _player.Draw(_spriteBatch);
                _projectileManager.DrawProjectiles(_spriteBatch);
                _asteroidManager.DrawAsteroids(_spriteBatch);

                HudDrawer.DrawHud(_spriteBatch, _gameFont, _player);
            }
            else if (_gameState == GameState.Menu)
            {
                MenuDrawer.DrawMainMenu(_spriteBatch, _gameFont);
            }
            else if (_gameState == GameState.GameOver)
            {
                MenuDrawer.DrawGameOverMenu(_spriteBatch, _gameFont);
            }
            else if (_gameState == GameState.Shop)
            {
                MenuDrawer.DrawShopMenu(_spriteBatch, _gameFont, _player);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
