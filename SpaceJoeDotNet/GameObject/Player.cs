using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.GameObject;

class Player : BaseWorldObject
{
    int _score,
        _totalScore,
        _credits,
        _hp,
        _shield;
    
    KeyboardState _previousKstate;
    
    public Player(Texture2D texture, Vector2 position) : base(position)
    {
        Texture = texture;
        Speed = 240;
    }

    public override void Update(GameTime gameTime)
    {
        var kstate = Keyboard.GetState();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left) && X > Texture!.Width / 2)
            X -= Speed * dt;
        if (kstate.IsKeyDown(Keys.Right)
            && X < BaseGameClass.Instance!.Graphics.PreferredBackBufferWidth - Texture!.Width / 2)
            X += Speed * dt;
        if (kstate.IsKeyDown(Keys.Down) && Y < BaseGameClass.Instance!.Graphics.PreferredBackBufferHeight - Texture!.Height / 2)
            Y += Speed * dt;
        if (kstate.IsKeyDown(Keys.Up) && Y > Texture!.Height / 2) 
            Y -= Speed * dt;
        
        if (kstate.IsKeyDown(Keys.Space) && _previousKstate.IsKeyUp(Keys.Space))
            Projectile.AddProjectile(ProjectileType.Default, 
                new Vector2(X, Y - Texture!.Height / 2));

        _previousKstate = kstate;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (Texture is not null)
            spriteBatch.DrawCentered(Texture, Position);
    }
}