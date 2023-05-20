using System.Drawing;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Item;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject;

class Player : GameObjectBase
{
    const int DefaultHitPoints = 250;
    const int DefaultShieldPoints = 50;

    static readonly Vector2 defaultPosition = new(SpaceJoeGame.Instance.Graphics.PreferredBackBufferWidth / 2,
        SpaceJoeGame.Instance.Graphics.PreferredBackBufferHeight - 60);

    KeyboardState _previousKstate;

    public Player(IProjectileManager projectileManager) : base(defaultPosition)
    {
        Speed = 280;
        Weapon = new(projectileManager, ProjectileType.Default, 100, 4, 10);
        Damage = 50;
        HitPoints = DefaultHitPoints;
    }

    public Weapon Weapon { get; }
    public int ShieldPoints { get; set; } = DefaultShieldPoints;
    public int Score { get; set; }
    public int TotalScore { get; set; }
    
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

    public void Reset()
    {
        Score = 0;
        HitPoints = DefaultHitPoints;
        ShieldPoints = DefaultShieldPoints;
        Weapon.CurrentHeat = 0;
        Position = defaultPosition;
    }

    public override void TakeDamage(int damage)
    {
        ShieldPoints -= damage;
        if (ShieldPoints < 0)
        {
            HitPoints += ShieldPoints;
            ShieldPoints = 0;
        }
    }
}