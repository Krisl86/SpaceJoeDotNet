using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Utils;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{
    interface ICollisionManager
    {
        void Collide(Player player, List<Asteroid> asteroids, List<Projectile> projectiles, List<Alien> aliens);
        bool CheckCollisions(GameObjectBase obj1, GameObjectBase obj2);
    }

    class CollisionManager : ICollisionManager
    {
        public void Collide(Player player, List<Asteroid> asteroids, List<Projectile> projectiles, List<Alien> aliens)
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

            foreach (var alien in aliens)
            {
                if (CheckCollisions(player, alien))
                {
                    player.TakeDamage(alien.Damage);
                    alien.TakeDamage(player.Damage);

                    if (alien.HitPoints <= 0)
                        ScoreCounter.CountScoreFor(player, alien);
                }
            }

            foreach (var projectile in projectiles)
            {
                bool projectileCollided = false;
                foreach (var asteroid in asteroids)
                {
                    if (projectile.Owner is not Alien && CheckCollisions(projectile, asteroid))
                    {
                        asteroid.TakeDamage(projectile.Damage);
                        projectile.TakeDamage(asteroid.Damage);

                        if (asteroid.HitPoints <= 0)
                            ScoreCounter.CountScoreFor(player, asteroid);

                        projectileCollided = true;
                        break;
                    }
                }

                if (projectileCollided)
                    continue;

                foreach (var alien in aliens)
                {
                    if (projectile.Owner is not Alien && CheckCollisions(projectile, alien))
                    {
                        alien.TakeDamage(projectile.Damage);
                        projectile.TakeDamage(alien.Damage);

                        if (alien.HitPoints <= 0)
                            ScoreCounter.CountScoreFor(player, alien);

                        projectileCollided = true;
                        break;
                    }
                }

                if (projectileCollided)
                    continue;

                if (projectile.Owner != player && CheckCollisions(player, projectile))
                {
                    player.TakeDamage(projectile.Damage);
                    projectile.TakeDamage(player.Damage);
                }
            }
        }

        public bool CheckCollisions(GameObjectBase obj1, GameObjectBase obj2)
        {
            int radius = obj1.Width / 2 + obj2.Width / 2;
            return Vector2.Distance(obj1.Position, obj2.Position) < radius;
        }
    }
}
