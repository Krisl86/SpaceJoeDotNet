using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        _asteroidLargeSprite;

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


            // because game items are dependent on their texture (and 'LoadContent' is called after 'Initialize'),
            // they need to be initialized here
            InitItemManagerTextures();

            _player = new(_playerSprite, new Vector2(Graphics.PreferredBackBufferWidth / 2,
            Graphics.PreferredBackBufferHeight - 60));
            _background = new(_bgBackSprite, _bgFrontSprite);
        }

        void InitItemManagerTextures()
        {
            Projectile.Manager.Textures.Add("projectileDefault", _projectileDefaultSprite);
            Projectile.Manager.Textures.Add("projectileSlow", _projectileSlowSprite);
            Projectile.Manager.Textures.Add("projectileFast", _projectileFastSprite);

            Asteroid.Manager.Textures.Add("asteroidSmall", _asteroidSmallSprite);
            Asteroid.Manager.Textures.Add("asteroidMedium", _asteroidMediumSprite);
            Asteroid.Manager.Textures.Add("asteroidLarge", _asteroidLargeSprite);
        }
    }
}
