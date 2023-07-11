using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager.Interfaces
{
    interface ICollisionManager
    {
        void Collide(IPlayer player, IEnumerable<IAsteroid> asteroids, IEnumerable<IProjectile> projectiles, IEnumerable<IAlien> aliens);
        bool CheckCollisions(ICollidableGameObject obj1, ICollidableGameObject obj2);
    }
}
