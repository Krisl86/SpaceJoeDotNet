using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        bool _someKeyDown;

        protected override void Update(GameTime gameTime)
        {
            if (_gameState == GameState.InGame)
                InGame(gameTime);
            else if (_gameState == GameState.Menu)
                Menu(gameTime);
            else if (_gameState == GameState.GameOver)
                GameOver(gameTime);
            else if (_gameState == GameState.Shop)
                Shop(gameTime);

            base.Update(gameTime);
        }

        void InGame(GameTime gameTime)
        {
            _asteroidManager.RandomlyGenerateAsteroid(Width);
            _alienManager.RandomlyGenerateAlien(Width, _projectileManager);
            _alienManager.RandomlyShoot(_player, Height);
            _background.Update(gameTime);

            _collisionManager.Collide(_player, _asteroidManager.Asteroids, _projectileManager.Projectiles, 
                _alienManager.Aliens);

            _projectileManager.UpdateProjectiles(gameTime, Width, Height);
            _asteroidManager.UpdateAsteroids(gameTime, Height);
            _alienManager.UpdateAliens(gameTime, Width, Height);

            _player.Update(gameTime, Width, Height);

            if (_player.HitPoints <= 0)
            {
                _gameState = GameState.GameOver;
                ResetGame();
            }
        }

        void Menu(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.N))
                _gameState = GameState.InGame;
            else if (Keyboard.GetState().IsKeyDown(Keys.L) && _saveLoadManager.SaveFileExists)
            {
                if (_saveLoadManager.Load(ref _player))
                {
                    ResetGame();
                    _gameState = GameState.InGame;
                }
                else
                {
                    _loadError = true;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                Exit();
        }

        void GameOver(GameTime gameTime)
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

        void Shop(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.B) && !_someKeyDown)
                _gameState = GameState.GameOver;
            else if (Keyboard.GetState().IsKeyDown(Keys.D1) && !_someKeyDown)
                _upgradesManager.PurchaseUpgrade(0);
            else if (Keyboard.GetState().IsKeyDown(Keys.D2) && !_someKeyDown)
                _upgradesManager.PurchaseUpgrade(1);
            else if (Keyboard.GetState().IsKeyDown(Keys.D3) && !_someKeyDown)
                _upgradesManager.PurchaseUpgrade(2);
            else if (Keyboard.GetState().IsKeyDown(Keys.D4) && !_someKeyDown)
                _upgradesManager.PurchaseUpgrade(3);
            else if (Keyboard.GetState().IsKeyDown(Keys.D5) && !_someKeyDown)
                _upgradesManager.PurchaseUpgrade(4);
            else if (Keyboard.GetState().IsKeyDown(Keys.D6) && !_someKeyDown)
                _upgradesManager.PurchaseUpgrade(5);

            _someKeyDown = Keyboard.GetState().GetPressedKeyCount() > 0;
        }
    }
}
