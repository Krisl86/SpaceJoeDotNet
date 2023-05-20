#nullable disable

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceJoeDotNet.Collision;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Bg;
using SpaceJoeDotNet.Utils;
using Color = Microsoft.Xna.Framework.Color;

namespace SpaceJoeDotNet;

enum GameState
{
    Menu,
    InGame,
    Paused,
    GameOver,
    Shop
}

public partial class SpaceJoeGame : Game
{
    SpriteBatch _spriteBatch;
    
    SpriteFont _gameFont;

    Player _player;
    Background _background;

    float _scoreCounter;
    GameState _gameState = GameState.Menu;


    public SpaceJoeGame()
    {
        Instance = this;
        Graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true; 
    }

    public GraphicsDeviceManager Graphics { get; }
    public static SpaceJoeGame Instance { get; private set; }
    
    protected override void Initialize()
    {
        Graphics.PreferredBackBufferWidth = 480;
        Graphics.PreferredBackBufferHeight = 720;
        Graphics.ApplyChanges();
        
        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (_gameState == GameState.InGame)
        {
            Asteroid.Manager.RandomlyGenerateAsteroid();

            _background.Update(gameTime);
            _player.Update(gameTime);
            _player.Weapon.Update(gameTime);
            Projectile.Manager.UpdateProjectiles(gameTime);
            Asteroid.Manager.UpdateAsteroids(gameTime);

            CollisionManager.Collide(_player);

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
            Projectile.Manager.DrawProjectiles(_spriteBatch);
            Asteroid.Manager.DrawAsteroids(_spriteBatch);

            HudDrawer.DrawHud(_spriteBatch, _gameFont, _player);
        }
        else if (_gameState == GameState.Menu)
            MenuDrawer.DrawMainMenu(_spriteBatch, _gameFont);
        else if (_gameState == GameState.GameOver)
            MenuDrawer.DrawGameOverMenu(_spriteBatch, _gameFont);
        else if (_gameState == GameState.Shop)
            MenuDrawer.DrawShopMenu(_spriteBatch, _gameFont, _player);

        _spriteBatch.End();

            base.Draw(gameTime);
    }

    void ResetGame()
    {
        _player.Reset();
        Projectile.Manager.Reset();
        Asteroid.Manager.Reset();
    }
}