using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using System;

namespace SpaceJoeDotNet.GameObject;

enum ProjectileType
{
    Default,
    Slow,
    Fast,
    Ball
}

class Projectile : GameObjectBase
{
    public Projectile(ProjectileType projectileType, Vector2 position, Vector2 direction, int damage) : base(position)
    {
        ProjectileType = projectileType;
        HitPoints = 1;
        Damage = damage;
        InitPropertiesByType(projectileType);
        direction.Normalize();
        Direction = direction;
    }

    public ProjectileType ProjectileType { get; }
    public Vector2 Direction { get; }

    public override void Update(GameTime gameTime)
    {
        float dt = gameTime.DeltaTime();
        X += Speed * Direction.X * dt;
        Y += Speed * Direction.Y * dt;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (Texture is not null)
            spriteBatch.DrawCentered(Texture, Position);
    }

    void InitPropertiesByType(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.Default:
                Speed = 500;
                break;
            case ProjectileType.Slow:
                Speed = 350;
                break;
            case ProjectileType.Fast:
                Speed = 750;
                break;
            case ProjectileType.Ball:
                Speed = 400;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}