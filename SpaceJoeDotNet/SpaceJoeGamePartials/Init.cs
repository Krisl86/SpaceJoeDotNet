using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet
{
    public partial class SpaceJoeGame : Game
    {
        protected override void Initialize()
        {
            Graphics.PreferredBackBufferWidth = 480;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();

            _asteroidManager = new();
            _projectileManager = new();

            _player = new(_projectileManager);

            base.Initialize();
        }
    }
}
