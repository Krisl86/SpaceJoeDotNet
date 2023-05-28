using Microsoft.Xna.Framework;
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
    public Projectile(GameObjectBase owner, ProjectileType projectileType, Vector2 position, Vector2 direction, int damage) : base(position)
    {
        Owner = owner;
        ProjectileType = projectileType;
        HitPoints = 1;
        Damage = damage;
        InitPropertiesByType(projectileType);
        direction.Normalize();
        Direction = direction;
    }

    public GameObjectBase Owner { get; }
    public ProjectileType ProjectileType { get; }
    public Vector2 Direction { get; }

    public override void Update(GameTime gameTime)
    {
        float dt = gameTime.DeltaTime();
        X += Speed * Direction.X * dt;
        Y += Speed * Direction.Y * dt;
    }

    void InitPropertiesByType(ProjectileType type)
    {
        Speed = type switch
        {
            ProjectileType.Default => 500,
            ProjectileType.Slow => 350,
            ProjectileType.Fast => 750,
            ProjectileType.Ball => 400,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }
}