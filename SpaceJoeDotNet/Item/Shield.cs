using Microsoft.Xna.Framework;
using MonogameCustomLibrary;
using SpaceJoeDotNet.Item.Interfaces;
using SpaceJoeDotNet.Misc.Interfaces.Damage;
using System;

namespace SpaceJoeDotNet.Item
{
    class Shield : IShield
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
        public float RecoveryDelay { get; set; }
        public float RecoveryTime { get; set; }
        public float DelayCounter { get; private set; }
        public int HitPoints { get; set; }

        public void Update(GameTime gameTime)
        {
            if (HitPoints < MaxHitPoints)
            {
                float dt = gameTime.DeltaTime();
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

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            DelayCounter = 0;

            if (HitPoints < 0)
                HitPoints = 0;
        }

        public void Reset()
        {
            HitPoints = MaxHitPoints;
        }
    }
}
