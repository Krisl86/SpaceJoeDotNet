using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameObject
{
    enum Direction
    {
        Forward,
        Left,
        Right
    }

    class Alien : GameObjectBase
    {
        Random _rand = new();
        float _directionChangeCounter;
        float _directionChangeTime;
        Direction _direction = Direction.Forward;

        public Alien(IProjectileManager projectileManager, Vector2 position) : base(position)
        {
            Speed = 360;
            HitPoints = 125;
            Damage = 100;
            Weapon = new(projectileManager, ProjectileType.Ball, 50, 1, 5);
            _directionChangeTime = _rand.Next(1, 3);
        }

        public Weapon Weapon { get; }

        public void Update(GameTime gameTime, int windowWidth)
        {
            float dt = gameTime.DeltaTime();

            if (_direction == Direction.Left)
                X -= Speed * dt;
            else if (_direction == Direction.Right)
                X += Speed * dt;

            _directionChangeCounter += dt;
            if (_directionChangeCounter >= _directionChangeTime)
            {
                _direction = (Direction)_rand.Next(0, 3);
                _directionChangeTime = (float)_rand.Next(100, 240) / 100;
                _directionChangeCounter = 0;
            }

            if (X < Width / 2 && _direction == Direction.Left)
                _direction = Direction.Right;
            if (X > windowWidth - Width / 2 && _direction == Direction.Right)
                _direction = Direction.Left;

            Y += Speed * dt;
        }

        public void Shoot(Vector2 direction) =>  Weapon.Shoot(this, new Vector2(X, Y + Height / 2), direction);

        public override void Update(GameTime gameTime) => throw new NotImplementedException();
    }
}
