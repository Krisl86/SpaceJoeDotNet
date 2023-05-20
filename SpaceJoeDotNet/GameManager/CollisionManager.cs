using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Utils;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{
    static class CollisionManager
    {
        public static void Collide(Player player, List<Asteroid> asteroids, List<Projectile> projectiles)
        {
            foreach (var asteroid in asteroids)
            {
                if (CheckCollisions(player, asteroid))
                {
                    player.TakeDamage(asteroid.Damage);
                    asteroid.TakeDamage(player.Damage);
                }
            }

            foreach (var projectile in projectiles)
            {
                foreach (var asteroid in asteroids)
                {
                    if (CheckCollisions(projectile, asteroid))
                    {
                        asteroid.TakeDamage(projectile.Damage);
                        if (asteroid.HitPoints <= 0)
                            ScoreCounter.CountScoreFor(player, asteroid);
                        projectile.TakeDamage(asteroid.Damage);
                    }
                }
            }
        }

        static bool CheckCollisions(GameObjectBase obj1, GameObjectBase obj2)
        {
            int radius = obj1.Texture.Width / 2 + obj2.Texture.Width / 2;
            return Vector2.Distance(obj1.Position, obj2.Position) < radius;
        }
    }
}
