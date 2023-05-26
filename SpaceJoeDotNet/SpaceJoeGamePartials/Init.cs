using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        Alien? alien;


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
            alien = new(_projectileManager, new Vector2(200, 0)) { Speed = 100 };

            base.Initialize();
        }
    }
}
