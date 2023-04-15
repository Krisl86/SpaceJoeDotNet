using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.GameObject;

class Projectile : BaseWorldObject
{
    public static LinkedList<Projectile> Projectiles { get; } = new();

    public Projectile(Vector2 position) : base(position)
    {
    }

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Draw(SpriteBatch spriteBatch, bool beginAndEndSpriteBatch = false)
    {
        throw new System.NotImplementedException();
    }
}