using Microsoft.Xna.Framework;
using SpaceJoeDotNet.Utils;
using System;

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

                HudDrawer.DrawHud(_spriteBatch, _gameFont, _player, Width);
            }
            else if (_gameState == GameState.Menu)
            {
                MenuDrawer.DrawMainMenu(_spriteBatch, _gameFont, Width, Height, _saveLoadManager.SaveFileExists,
                    _loadError);
            }
            else if (_gameState == GameState.GameOver)
            {
                MenuDrawer.DrawGameOverMenu(_spriteBatch, _gameFont, Width, Height, _gameSaved);
            }
            else if (_gameState == GameState.Shop)
            {
                MenuDrawer.DrawShopMenu(_spriteBatch, _gameFont, _player, Width, Height);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
