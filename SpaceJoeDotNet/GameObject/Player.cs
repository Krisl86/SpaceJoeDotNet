using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Item;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject;

class Player : BaseWorldObject
{
    KeyboardState _previousKstate;

    public Player(Texture2D texture, Vector2 position) : base(texture, position)
    {
        Speed = 240;
        CurrentWeapon = ItemManager.Weapons.First(w => w.Name == "Old Rusty Laser");
    }

    public Weapon CurrentWeapon { get; }
    
    public override void Update(GameTime gameTime)
    {
        var kstate = Keyboard.GetState();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left) && X > Texture.Width / 2)
            X -= Speed * dt;
        if (kstate.IsKeyDown(Keys.Right)
            && X < SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth - Texture.Width / 2)
            X += Speed * dt;
        if (kstate.IsKeyDown(Keys.Down) && Y < SpaceJoeGame.Instance.Graphics.PreferredBackBufferHeight - Texture.Height / 2)
            Y += Speed * dt;
        if (kstate.IsKeyDown(Keys.Up) && Y > Texture.Height / 2) 
            Y -= Speed * dt;
        
        if (kstate.IsKeyDown(Keys.Space) && _previousKstate.IsKeyUp(Keys.Space))
            CurrentWeapon.Shoot(new Vector2(X, Y - Texture.Height / 2));

        _previousKstate = kstate;
    }

    public override void Draw(SpriteBatch spriteBatch)
        => spriteBatch.DrawCentered(Texture, Position);
}