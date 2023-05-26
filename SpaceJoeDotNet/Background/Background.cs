using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameCustomLibrary;

namespace SpaceJoeDotNet.Bg;

class Background
{
    const int BackSpeed = 200;
    const int FrontSpeed = 550;

    readonly Texture2D _backSprite;
    readonly Texture2D _frontSprite;

    float _backY;
    float _frontY;

    readonly int _backStartY;
    readonly int _frontStartY;

    public Background(Texture2D backSprite, Texture2D frontSprite, int windowHeight)
    {
        _backSprite = backSprite;
        _frontSprite = frontSprite;
        _backStartY = -backSprite.Height + windowHeight;
        _frontStartY = -frontSprite.Height + windowHeight;
        _backY = _backStartY;
        _frontY = _frontStartY;
    }

    public void Update(GameTime gameTime)
    {
        float dt = gameTime.DeltaTime();
        _backY += BackSpeed * dt;
        _frontY += FrontSpeed * dt;

        if (_backY >= 0)
            _backY = _backStartY;
        if (_frontY >= 0)
            _frontY = _frontStartY;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_backSprite, new Vector2(0, _backY), Color.White);
        spriteBatch.Draw(_frontSprite, new Vector2(0, _frontY), Color.White);
    }
}