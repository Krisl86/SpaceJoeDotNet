using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Utils;
using System.Collections.Generic;

namespace SpaceJoeDotNet.GameManager
{

    class CollisionManager : ICollisionManager
    {
        public void Collide(IPlayer player, IEnumerable<IAsteroid> asteroids, IEnumerable<IProjectile> projectiles, IEnumerable<IAlien> aliens)
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

        public bool CheckCollisions(ICollidableGameObject obj1, ICollidableGameObject obj2)
        {
            int radius = obj1.Texture.Width / 2 + obj2.Texture.Width / 2;
            return Vector2.Distance(obj1.Position, obj2.Position) < radius;
        }
    }
}
