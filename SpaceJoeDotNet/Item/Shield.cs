using Microsoft.Xna.Framework;
using System;

namespace SpaceJoeDotNet.Item
{
    class Shield
    {
        float _delayCounter;
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

        public void Update(GameTime gameTime)
        {
            if (HitPoints < MaxHitPoints)
            {
                float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
                _delayCounter += dt;
                if (_delayCounter >= RecoveryDelay)
                {
                    _recoveryCounter += dt;
                    if (_recoveryCounter >= RecoveryTime)
                    {
                        HitPoints++;
                        if (HitPoints >= MaxHitPoints)
                        {
                            _recoveryCounter = 0;
                            _delayCounter = 0;
                        }
                    }
                }
            }
        }

        public int TakeDamage(int damage)
        {
            int remainingDamage = 0;
            HitPoints -= damage;
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
