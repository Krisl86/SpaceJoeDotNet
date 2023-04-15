using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.GameObject;

enum ProjectileType
{
    Default,
    Slow,
    Fast
}

class Projectile : BaseWorldObject
{
    public static List<Projectile> Projectiles { get; } = new();

    public static Dictionary<string, Texture2D> Textures { get; } = new();

    public static void AddProjectile(ProjectileType type, Vector2 position)
    {
        Texture2D texture;
        int speed;

        switch (type)
        {
            case ProjectileType.Default:
                texture = Textures["projectileDefault"];
                speed = 500;
                break;
            case ProjectileType.Slow:
                texture = Textures["projectileSlow"];
                speed = 350;
                break;
            case ProjectileType.Fast:
                texture = Textures["projectileFast"];
                speed = 700;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        Projectiles.Add(new Projectile(texture, position) {Speed = speed});
    }
    public static void DrawProjectiles(SpriteBatch spriteBatch)
        => Projectiles.ForEach(p => p.Draw(spriteBatch));

    public static void UpdateProjectiles(GameTime gameTime)
    {
        for (var i = 0; i < Projectiles.Count; i++)
        {
            if (Projectiles.Count > 30) // remove off-screen projectiles every once in a while
            {
                if (Projectiles[i].Y < 0)
                    Projectiles.RemoveAt(i);
                return;
            }
            else
                Projectiles[i].Update(gameTime);
        }
    }

    public override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Y -= Speed * dt;
    }

    public Projectile(Texture2D texture, Vector2 position) : base(position)
    {
        Texture = texture;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (Texture is not null)
            spriteBatch.DrawCentered(Texture, Position);
    }
}