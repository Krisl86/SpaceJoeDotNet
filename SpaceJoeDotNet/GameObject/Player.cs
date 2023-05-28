using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Item;
using System;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject;

class Player : GameObjectBase
{
    const int DefaultHitPoints = 100;

    float _scoreCounter;
    KeyboardState _previousKstate;

    public Player(IProjectileManager projectileManager, Vector2 defaultPosition) : base(defaultPosition)
    {
        Speed = 280;
        Weapon = new(projectileManager, ProjectileType.Default, 100, 4, 10);
        Shield = new(150, 10, 0.1f);
        Damage = 9999;
        HitPoints = DefaultHitPoints;
        DefaultPosition = defaultPosition;
        TotalScore = 99999;
    }

    public Vector2 DefaultPosition { get; set; }
    public Weapon Weapon { get; }
    public Shield Shield { get; set; }
    public int Score { get; set; }
    public int TotalScore { get; set; }

    public void Update(GameTime gameTime, int windowWidth, int windowHeight)
    {
        var kstate = Keyboard.GetState();
        float dt = gameTime.DeltaTime();

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
            Weapon.Shoot(this, new Vector2(X, Y - Height / 2), new Vector2(0, -1));

        _previousKstate = kstate;

        _scoreCounter += 0.01f;
        if (_scoreCounter >= 1)
        {
            Score += 4;
            _scoreCounter = 0;
        }

        Weapon.Update(gameTime);
        Shield.Update(gameTime);
    }

    public void Reset()
    {
        TotalScore += Score;
        Score = 0;
        HitPoints = DefaultHitPoints;
        Position = DefaultPosition;
        Shield.Reset();
        Weapon.Reset();
    }

    public override void TakeDamage(int damage)
    {
        int remainingDamage = Shield.TakeDamage(damage);
        HitPoints -= remainingDamage;
    }

    public override void Update(GameTime gameTime) => throw new NotImplementedException();
}