using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet;

public class SpaceJoeGame : BaseGameClass
{
    SpriteFont _gameFont = null!;
    Texture2D _projectileDefault = null!;
    
    public SpaceJoeGame()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true; 
    }

    protected override void Initialize()
    {
        Graphics.PreferredBackBufferWidth = 1280;
        Graphics.PreferredBackBufferHeight = 720;
        Graphics.ApplyChanges();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new(GraphicsDevice);

        _gameFont = Content.Load<SpriteFont>("gamefont");
        _projectileDefault = Content.Load<Texture2D>("projectile-default");
        
        Projectile.Textures.Add("projectileDefault", _projectileDefault);
        Projectile.AddProjectile(ProjectileType.Default, new Vector2(200, 600));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Projectile.UpdateProjectiles(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin();
        
        Projectile.DrawProjectiles(SpriteBatch);
        
        SpriteBatch.End();
        
        base.Draw(gameTime);
    }
}