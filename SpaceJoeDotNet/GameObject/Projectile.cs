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
    Fast
}

class Projectile : GameObjectBase
{
    public Projectile(ProjectileType projectileType, Vector2 position, int damage) : base(position)
    {
        ProjectileType = projectileType;
        HitPoints = 1;
        Damage = damage;
        InitPropertiesByType(projectileType);
    }

    public ProjectileType ProjectileType { get; }

    public override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Y -= Speed * dt;
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
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}