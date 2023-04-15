using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.GameObject;

class Player : BaseWorldObject
{
    int _score,
        _totalScore,
        _credits,
        _hp,
        _shield;

    public Player(Vector2 position) : base(position)
    {
        Speed = 240;
    }

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        throw new System.NotImplementedException();
    }
}