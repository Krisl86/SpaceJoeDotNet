using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Collision;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Item;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject;

class Player : GameObjectBase
{
    const int DefaultHullPoints = 250;
    const int DefaultShieldPoints = 50;

    KeyboardState _previousKstate;

    public Player(Texture2D texture, Vector2 position) : base(texture, position)
    {
        Speed = 240;
        Weapon = new(ProjectileType.Default, 150, 4, 10);
    }

    public Weapon Weapon { get; }
    public int HullPoints { get; set; } = DefaultHullPoints;
    public int ShieldPoints { get; set; } = DefaultShieldPoints;
    public int Score { get; set; }
    
    public bool Collided { get; set; }
    public int Damage => 0;

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
            Weapon.Shoot(new Vector2(X, Y - Texture.Height / 2));

        _previousKstate = kstate;
    }

    public override void Draw(SpriteBatch spriteBatch)
        => spriteBatch.DrawCentered(Texture, Position);

    public void CollidedWith(Asteroid other)
    {
        ShieldPoints -= other.Damage;
        if (ShieldPoints < 0)
        {
            HullPoints += ShieldPoints;
            ShieldPoints = 0;
        }
    }

    public void Reset()
    {
        Score = 0;
        HullPoints = DefaultHullPoints;
        ShieldPoints = DefaultShieldPoints;
        Weapon.CurrentHeat = 0;
    }
}