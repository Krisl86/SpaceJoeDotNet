using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Utils;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        Texture2D _projectileDefaultSprite,
        _projectileSlowSprite,
        _projectileFastSprite,
        _playerSprite,
        _bgFrontSprite,
        _bgBackSprite,
        _asteroidSmallSprite,
        _asteroidMediumSprite,
        _asteroidLargeSprite,
        _mainMenuSprite,
        _gameOverSprite;

        protected override void LoadContent()
        {
            _spriteBatch = new(GraphicsDevice);

            _gameFont = FontExists("Ethnocentric Rg") ?
                Content.Load<SpriteFont>("gamefont") : Content.Load<SpriteFont>("defaultFont");

            _projectileDefaultSprite = Content.Load<Texture2D>("projectile-default");
            _projectileSlowSprite = Content.Load<Texture2D>("projectile-slow");
            _projectileFastSprite = Content.Load<Texture2D>("projectile-fast");
            _playerSprite = Content.Load<Texture2D>("ship");
            _bgFrontSprite = Content.Load<Texture2D>("bg-front");
            _bgBackSprite = Content.Load<Texture2D>("bg-back");
            _asteroidSmallSprite = Content.Load<Texture2D>("asteroid-small");
            _asteroidMediumSprite = Content.Load<Texture2D>("asteroid-medium");
            _asteroidLargeSprite = Content.Load<Texture2D>("asteroid-large");
            _mainMenuSprite = Content.Load<Texture2D>("shop");
            _gameOverSprite = Content.Load<Texture2D>("game-over");


            // because game items are dependent on their texture (and 'LoadContent' is called after 'Initialize'),
            // they need to be initialized here
            InitTexturesForOthers();

            _player = new(_playerSprite, new Vector2(Graphics.PreferredBackBufferWidth / 2,
            Graphics.PreferredBackBufferHeight - 60));
            _background = new(_bgBackSprite, _bgFrontSprite);
        }

        void InitTexturesForOthers()
        {
            Projectile.Manager.Textures.Add("projectileDefault", _projectileDefaultSprite);
            Projectile.Manager.Textures.Add("projectileSlow", _projectileSlowSprite);
            Projectile.Manager.Textures.Add("projectileFast", _projectileFastSprite);

            Asteroid.Manager.Textures.Add("asteroidSmall", _asteroidSmallSprite);
            Asteroid.Manager.Textures.Add("asteroidMedium", _asteroidMediumSprite);
            Asteroid.Manager.Textures.Add("asteroidLarge", _asteroidLargeSprite);

            MenuDrawer.MainMenuBackground = _mainMenuSprite;
            MenuDrawer.GameOverMenuBackground = _gameOverSprite;
        }
    }
}
