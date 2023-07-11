using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager.Interfaces
{
    interface IAlienManager : IResetable
    {
        List<IAlien> Aliens { get; }

        void RandomlyGenerateAlien(int windowWidth, IProjectileManager projectileManager);
        void RandomlyShoot(IBaseSpaceJoeGameObject target, int windowHeight);
        void AddAlien(Vector2 position, IProjectileManager projectileManager);
        void DrawAliens(SpriteBatch spriteBatch);
        void UpdateAliens(GameTime gameTime, int windowWidth, int windowHeight);
    }
}
