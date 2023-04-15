using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet;

public class SpaceJoeGame : BaseGameClass
{
    SpriteFont _gameFont = null!;

    Texture2D _projectileDefaultSprite = null!,
        _playerSprite = null!;

    Player _player = null!;

    public SpaceJoeGame()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true; 
    }

    protected override void Initialize()
    {
        Graphics.PreferredBackBufferWidth = 480;
        Graphics.PreferredBackBufferHeight = 720;
        Graphics.ApplyChanges();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);

        _gameFont = Content.Load<SpriteFont>("gamefont");
        _projectileDefaultSprite = Content.Load<Texture2D>("projectile-default");
        _playerSprite = Content.Load<Texture2D>("ship");
        
        Projectile.Textures.Add("projectileDefault", _projectileDefaultSprite);

        _player = new(_playerSprite, new Vector2(Graphics.PreferredBackBufferWidth / 2,
            Graphics.PreferredBackBufferHeight - 60));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _player.Update(gameTime);
        Projectile.UpdateProjectiles(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        if (SpriteBatch is null) 
            throw new NullReferenceException("SpriteBatch is null!");
        
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin();

        _player.Draw(SpriteBatch);
        Projectile.DrawProjectiles(SpriteBatch);

        SpriteBatch.End();

        base.Draw(gameTime);

    }
}