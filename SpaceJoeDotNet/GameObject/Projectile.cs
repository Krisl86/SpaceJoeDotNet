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
        Texture2D texture = type switch
        {
            ProjectileType.Default => Textures["projectileDefault"],
            ProjectileType.Slow => Textures["projectileSlow"],
            ProjectileType.Fast => Textures["projectileFast"],
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Projectile Texture was not found!")
        };

        Projectiles.Add(new Projectile(texture, position) {Speed = 200});
    }
    public static void DrawProjectiles(SpriteBatch spriteBatch)
        => Projectiles.ForEach(p => p.Draw(spriteBatch));

    public static void UpdateProjectiles(GameTime gameTime)
        => Projectiles.ForEach(p => p.Update(gameTime));

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