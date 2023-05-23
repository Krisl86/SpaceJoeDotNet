using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        protected override void Update(GameTime gameTime)
        {
            if (_gameState == GameState.InGame)
            {
                _asteroidManager.RandomlyGenerateAsteroid(Width);

                _background.Update(gameTime);

                _collisionManager.Collide(_player, _asteroidManager.Asteroids, _projectileManager.Projectiles);

                _projectileManager.UpdateProjectiles(gameTime);
                _asteroidManager.UpdateAsteroids(gameTime, Height);

                _player.Update(gameTime, Width, Height);

                if (_player.HitPoints <= 0)
                {
                    _gameState = GameState.GameOver;
                    ResetGame();
                }
            }
            else if (_gameState == GameState.Menu)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.N))
                    _gameState = GameState.InGame;
                else if (Keyboard.GetState().IsKeyDown(Keys.L) && _saveLoadManager.SaveFileExists)
                {
                    _saveLoadManager.Load(ref _player);
                    _gameState = GameState.InGame;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    Exit();
            }
            else if (_gameState == GameState.GameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    if (!_gameSaved)
                    {
                        _saveLoadManager.Save(_player);
                        _gameSaved = true;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    _gameSaved = false;
                    _gameState = GameState.InGame;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.U))
                {
                    _gameSaved = false;
                    _gameState = GameState.Shop;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    Exit();
            }
            else if (_gameState == GameState.Shop)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    _gameState = GameState.GameOver;
                }
            }

            base.Update(gameTime);
        }
    }
}
