using Microsoft.Xna.Framework;
using System;

namespace SpaceJoeDotNet.Item
{
    class Shield
    {
        float _recoveryCounter;

        public Shield(int maxHitPoints, float recoveryDelay, float recoveryTime)
        {
            MaxHitPoints = maxHitPoints;
            HitPoints = maxHitPoints;
            RecoveryDelay = recoveryDelay;
            RecoveryTime = recoveryTime;
        }

        public int MaxHitPoints { get; set; }
        public int HitPoints { get; private set; }
        public float RecoveryDelay { get; set; }
        public float RecoveryTime { get; set; }
        public float DelayCounter { get; private set; }

        public void Update(GameTime gameTime)
        {
            if (HitPoints < MaxHitPoints)
            {
                float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
                DelayCounter += dt;
                if (DelayCounter >= RecoveryDelay)
                {
                    _recoveryCounter += dt;
                    if (_recoveryCounter >= RecoveryTime)
                    {
                        HitPoints++;
                        _recoveryCounter = 0;
                        if (HitPoints >= MaxHitPoints)
                            DelayCounter = 0;
                    }
                }
            }
        }

        public int TakeDamage(int damage)
        {
            int remainingDamage = 0;
            HitPoints -= damage;
            DelayCounter = 0;

            if (HitPoints < 0)
            {
                remainingDamage = Math.Abs(HitPoints);
                HitPoints = 0;
            }

            return remainingDamage;
        }

        public void Reset()
        {
            HitPoints = MaxHitPoints;
        }
    }
}
