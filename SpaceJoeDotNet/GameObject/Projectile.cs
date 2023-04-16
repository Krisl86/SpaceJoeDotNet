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

interface IProjectileManager
{
    List<Projectile> Projectiles { get; }
    Dictionary<string, Texture2D> Textures { get; }
    void AddProjectile(ProjectileType type, Vector2 position, int damage);
    void DrawProjectiles(SpriteBatch spriteBatch);
    void UpdateProjectiles(GameTime gameTime);
}

class Projectile : BaseWorldObject
{
    class ProjectileManager : IProjectileManager
    {
        public List<Projectile> Projectiles { get; } = new();
        public Dictionary<string, Texture2D> Textures { get; } = new();
    
        public void AddProjectile(ProjectileType type, Vector2 position, int damage)
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
            
            Projectiles.Add(new Projectile(texture, position, damage) {Speed = speed});
        }
    
        public void DrawProjectiles(SpriteBatch spriteBatch)
            => Projectiles.ForEach(p => p.Draw(spriteBatch));
    
        public void UpdateProjectiles(GameTime gameTime)
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
    }
    
    public static IProjectileManager Manager = new ProjectileManager();

    int _damage;
    
    Projectile(Texture2D texture, Vector2 position, int damage) : base(texture, position)
    {
        _damage = damage;
    }

    public override void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Y -= Speed * dt;
    }
    
    public override void Draw(SpriteBatch spriteBatch)
        => spriteBatch.DrawCentered(Texture, Position);
}