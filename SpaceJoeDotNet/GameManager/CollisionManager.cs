using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Utils;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{
    interface ICollisionManager
    {
        void Collide(Player player, List<Asteroid> asteroids, List<Projectile> projectiles);
    }

    class CollisionManager : ICollisionManager
    {
        public void Collide(Player player, List<Asteroid> asteroids, List<Projectile> projectiles)
        {
            foreach (var asteroid in asteroids)
            {
                if (CheckCollisions(player, asteroid))
                {
                    player.TakeDamage(asteroid.Damage);
                    asteroid.TakeDamage(player.Damage);

                    if (asteroid.HitPoints <= 0)
                        ScoreCounter.CountScoreFor(player, asteroid);
                }
            }

            foreach (var projectile in projectiles)
            {
                foreach (var asteroid in asteroids)
                {
                    if (CheckCollisions(projectile, asteroid))
                    {
                        asteroid.TakeDamage(projectile.Damage);
                        projectile.TakeDamage(asteroid.Damage);

                        if (asteroid.HitPoints <= 0)
                            ScoreCounter.CountScoreFor(player, asteroid);
                    }
                }
            }
        }

        bool CheckCollisions(GameObjectBase obj1, GameObjectBase obj2)
        {
            int radius = obj1.Width / 2 + obj2.Width / 2;
            return Vector2.Distance(obj1.Position, obj2.Position) < radius;
        }
    }
}
