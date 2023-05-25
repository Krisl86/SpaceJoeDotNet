using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceJoeDotNet.Bg;
using SpaceJoeDotNet.GameObject;
using System;

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

        void Menu(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.N))
                _gameState = GameState.InGame;
            else if (Keyboard.GetState().IsKeyDown(Keys.L) && _saveLoadManager.SaveFileExists)
            {
                if (_saveLoadManager.Load(ref _player))
                    _gameState = GameState.InGame;
                else
                    _loadError = true;
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
                _upgradesManager.UpgradeWeaponDamage();
            else if (Keyboard.GetState().IsKeyDown(Keys.D2) && !_someKeyDown)
                _upgradesManager.UpgradeWeaponCooldownTime();
            else if (Keyboard.GetState().IsKeyDown(Keys.D3) && !_someKeyDown)
                _upgradesManager.UpgradeWeaponHeatLimit();
            else if (Keyboard.GetState().IsKeyDown(Keys.D4) && !_someKeyDown)
                _upgradesManager.UpgradeShieldCapacity();
            else if (Keyboard.GetState().IsKeyDown(Keys.D5) && !_someKeyDown)
                _upgradesManager.UpgradeShieldRecoveryDelay();
            else if (Keyboard.GetState().IsKeyDown(Keys.D6) && !_someKeyDown)
                _upgradesManager.UpgradeShieldRecoveryTime();

            _someKeyDown = Keyboard.GetState().GetPressedKeyCount() > 0;
        }
    }
}
