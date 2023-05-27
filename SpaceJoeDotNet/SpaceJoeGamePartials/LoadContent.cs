using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.Utils;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        Texture2D _projectileDefaultSprite,
        _projectileSlowSprite,
        _projectileFastSprite,
        _projectileBallSprite,
        _playerSprite,
        _bgFrontSprite,
        _bgBackSprite,
        _asteroidSmallSprite,
        _asteroidMediumSprite,
        _asteroidLargeSprite,
        _mainMenuSprite,
        _gameOverSprite,
        _alienSprite;

        protected override void LoadContent()
        {
            _spriteBatch = new(GraphicsDevice);

            _gameFont = FontExists("Ethnocentric Rg") ?
                Content.Load<SpriteFont>("gamefont") : Content.Load<SpriteFont>("defaultFont");

            _projectileDefaultSprite = Content.Load<Texture2D>("projectile-default");
            _projectileSlowSprite = Content.Load<Texture2D>("projectile-slow");
            _projectileFastSprite = Content.Load<Texture2D>("projectile-fast");
            _projectileBallSprite = Content.Load<Texture2D>("projectile-ball");

            _playerSprite = Content.Load<Texture2D>("ship");
            _bgFrontSprite = Content.Load<Texture2D>("bg-front");
            _bgBackSprite = Content.Load<Texture2D>("bg-back");
            _asteroidSmallSprite = Content.Load<Texture2D>("asteroid-small");
            _asteroidMediumSprite = Content.Load<Texture2D>("asteroid-medium");
            _asteroidLargeSprite = Content.Load<Texture2D>("asteroid-large");
            _mainMenuSprite = Content.Load<Texture2D>("shop");
            _gameOverSprite = Content.Load<Texture2D>("game-over");

            _alienSprite = Content.Load<Texture2D>("alien");

            InitTexturesForManagers();

            _player.Texture = _playerSprite;
            _background = new(_bgBackSprite, _bgFrontSprite, Height);
        }

        void InitTexturesForManagers()
        {
            _projectileManager.Textures.Add("projectileDefault", _projectileDefaultSprite);
            _projectileManager.Textures.Add("projectileSlow", _projectileSlowSprite);
            _projectileManager.Textures.Add("projectileFast", _projectileFastSprite);
            _projectileManager.Textures.Add("projectileBall", _projectileBallSprite);

            _asteroidManager.Textures.Add("asteroidSmall", _asteroidSmallSprite);
            _asteroidManager.Textures.Add("asteroidMedium", _asteroidMediumSprite);
            _asteroidManager.Textures.Add("asteroidLarge", _asteroidLargeSprite);

            _alienManager.Textures.Add("alien", _alienSprite);

            MenuDrawer.DefaultMenuBackground = _mainMenuSprite;
            MenuDrawer.GameOverMenuBackground = _gameOverSprite;
        }
    }
}
