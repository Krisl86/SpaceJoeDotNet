using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.GameObject;

class Player : BaseWorldObject
{
    int _score,
        _totalScore,
        _credits,
        _hp,
        _shield;

    public Player(Texture2D texture, Vector2 position) : base(position)
    {
        Texture = texture;
        Speed = 240;
    }

    public override void Update(GameTime gameTime)
    {
        var kstate = Keyboard.GetState();
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left))
            X -= Speed * dt;
        if (kstate.IsKeyDown(Keys.Right))
            X += Speed * dt;
        if (kstate.IsKeyDown(Keys.Down))
            Y += Speed * dt;
        if (kstate.IsKeyDown(Keys.Up))
            Y -= Speed * dt;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (Texture is not null)
            spriteBatch.DrawCentered(Texture, Position);
    }
}