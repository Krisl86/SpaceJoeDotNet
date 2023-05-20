using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        protected override void Update(GameTime gameTime)
        {
            if (_gameState == GameState.InGame)
            {
                _asteroidManager.RandomlyGenerateAsteroid();

                _background.Update(gameTime);
                _player.Update(gameTime);
                _player.Weapon.Update(gameTime);

                _projectileManager.UpdateProjectiles(gameTime);
                _asteroidManager.UpdateAsteroids(gameTime);

                CollisionManager.Collide(_player, _asteroidManager.Asteroids, _projectileManager.Projectiles);

                if (_player.HitPoints <= 0)
                    _gameState = GameState.GameOver;

                _scoreCounter += 0.01f;
                if (_scoreCounter >= 1)
                {
                    _player.Score += 1;
                    _scoreCounter = 0;
                }
            }
            else if (_gameState == GameState.Menu)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.N))
                    _gameState = GameState.InGame;
                else if (Keyboard.GetState().IsKeyDown(Keys.L))
                    _gameState = GameState.InGame;
                else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    Exit();
            }
            else if (_gameState == GameState.GameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    ResetGame();
                    _gameState = GameState.InGame;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.U))
                {
                    ResetGame();
                    _gameState = GameState.Shop;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    Exit();
            }
            else if (_gameState == GameState.Shop)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    ResetGame();
                    _gameState = GameState.InGame;
                }
            }

            base.Update(gameTime);
        }
    }
}
