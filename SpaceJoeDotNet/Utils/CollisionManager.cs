using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.Utils
{
    static class CollisionManager
    {
        static bool CheckCollisions(BaseWorldObject obj1, BaseWorldObject obj2)
        {
            int radius = obj1.Width / 2 + obj2.Width / 2;
            return Vector2.Distance(obj1.Position, obj2.Position) < radius;
        }

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
    }
}
