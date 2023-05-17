using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Collision
{
    static class CollisionManager
    {
        public static void Collide(Player player)
        {
            foreach (var asteroid in Asteroid.Manager.Asteroids)
            {
                if (CheckCollisions(player, asteroid))
                {
                    asteroid.Collided = true;
                    player.CollidedWith(asteroid);
                }
            }

            foreach (var projectile in Projectile.Manager.Projectiles)
            {
                foreach (var asteroid in Asteroid.Manager.Asteroids)
                {
                    if (CheckCollisions(projectile, asteroid))
                    {
                        projectile.Collided = true;
                        asteroid.Collided = true;
                    }
                }
            }
        }

        static bool CheckCollisions(GameObjectBase obj1, GameObjectBase obj2)
        {
            int radius = obj1.Width / 2 + obj2.Width / 2;
            return Vector2.Distance(obj1.Position, obj2.Position) < radius;
        }
    }
}
