using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceJoeDotNet.GameObject;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet;

public class SpaceJoeGame : Game
{
    SpriteBatch _spriteBatch;
    
    SpriteFont _gameFont;

    Texture2D _projectileDefaultSprite,
        _playerSprite,
        _bgFrontSprite,
        _bgBackSprite;

    Player _player;
    Background _background;

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

    protected override void LoadContent()
    {
        _spriteBatch = new(GraphicsDevice);

        _gameFont = Content.Load<SpriteFont>("gamefont");
        _projectileDefaultSprite = Content.Load<Texture2D>("projectile-default");
        _playerSprite = Content.Load<Texture2D>("ship");
        _bgFrontSprite = Content.Load<Texture2D>("bg-front");
        _bgBackSprite = Content.Load<Texture2D>("bg-back");
        
        Projectile.Manager.Textures.Add("projectileDefault", _projectileDefaultSprite);

        _player = new(_playerSprite, new Vector2(Graphics.PreferredBackBufferWidth / 2,
            Graphics.PreferredBackBufferHeight - 60));

        _background = new(_bgBackSprite, _bgFrontSprite);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _background.Update(gameTime);
        
        _player.Update(gameTime);
        Projectile.Manager.UpdateProjectiles(gameTime);

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

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}