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

    float _scoreCounter;
    KeyboardState _previousKstate;

    public Player(IProjectileManager projectileManager, Vector2 defaultPosition) : base(defaultPosition)
    {
        Speed = 280;
        Weapon = new(projectileManager, ProjectileType.Default, 100, 4, 10);
        Damage = 50;
        HitPoints = DefaultHitPoints;
        DefaultPosition = defaultPosition;
    }

    public Vector2 DefaultPosition { get; set; }
    public Weapon Weapon { get; }
    public int ShieldPoints { get; set; } = DefaultShieldPoints;
    public int Score { get; set; }
    public int TotalScore { get; set; }
    
    public void Update(GameTime gameTime, int windowWidth, int windowHeight)
    {
        var kstate = Keyboard.GetState();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left) && X > Width / 2)
            X -= Speed * dt;
        if (kstate.IsKeyDown(Keys.Right)
            && X < windowWidth - Width / 2)
            X += Speed * dt;
        if (kstate.IsKeyDown(Keys.Down) && Y < windowHeight - Height / 2)
            Y += Speed * dt;
        if (kstate.IsKeyDown(Keys.Up) && Y > Height / 2) 
            Y -= Speed * dt;
        
        if (kstate.IsKeyDown(Keys.Space) && _previousKstate.IsKeyUp(Keys.Space))
            Weapon.Shoot(new Vector2(X, Y - Height / 2));

        _previousKstate = kstate;

        _scoreCounter += 0.01f;
        if (_scoreCounter >= 1)
        {
            Score += 1;
            _scoreCounter = 0;
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    { 
        if (Texture is not null)
            spriteBatch.DrawCentered(Texture, Position);
    }

    public void Reset()
    {
        Score = 0;
        HitPoints = DefaultHitPoints;
        ShieldPoints = DefaultShieldPoints;
        Weapon.CurrentHeat = 0;
        Position = DefaultPosition;
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

    public override void Update(GameTime gameTime) => Update(gameTime, 0, 0);
}