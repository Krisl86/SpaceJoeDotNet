using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        protected override void Initialize()
        {
            Graphics.PreferredBackBufferWidth = 480;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();

            _asteroidManager = new AsteroidManager();
            _projectileManager = new ProjectileManager();
            _collisionManager = new CollisionManager();
            _saveLoadManager = new();

            _player = new(_projectileManager, new Vector2(Width / 2, Height - 60));
            _upgradesManager = new(_player);

            base.Initialize();
        }
    }
}
