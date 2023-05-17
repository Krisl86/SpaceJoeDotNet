#nullable disable

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceJoeDotNet.Collision;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Utils;
using Color = Microsoft.Xna.Framework.Color;

namespace SpaceJoeDotNet;

public partial class SpaceJoeGame : Game
{
    SpriteBatch _spriteBatch;
    
    SpriteFont _gameFont;

    Player _player;
    Background _background;

    float _scoreCounter;

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
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Asteroid.Manager.RandomlyGenerateAsteroid();

        _background.Update(gameTime);
        _player.Update(gameTime);
        _player.CurrentWeapon.Update(gameTime);
        Projectile.Manager.UpdateProjectiles(gameTime);
        Asteroid.Manager.UpdateAsteroids(gameTime);

        CollisionManager.Collide(_player);

        _scoreCounter += 0.01f;
        if (_scoreCounter >= 1)
        {
            _player.Score += 1;
            _scoreCounter = 0;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (_spriteBatch is null) 
            throw new NullReferenceException("SpriteBatch is null!");
        
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        _background.Draw(_spriteBatch);
        
        _player.Draw(_spriteBatch);
        Projectile.Manager.DrawProjectiles(_spriteBatch);
        Asteroid.Manager.DrawAsteroids(_spriteBatch);

        HudDrawer.DrawHud(_spriteBatch, _gameFont, _player);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}