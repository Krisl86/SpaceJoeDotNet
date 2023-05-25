using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.GameManager
{
    class UpgradesManager
    {
        Player _player;

        public UpgradesManager(Player player)
        {
            _player = player;
        }

        public bool UpgradeWeaponDamage()
        {
            if (_player.TotalScore >= 200 && _player.Weapon.Damage < 300)
            {
                _player.Weapon.Damage += 35;
                return true;
            }
            else
                return false;
        }

        public bool UpgradeWeaponCooldownTime()
        {
            if (_player.TotalScore >= 350 && _player.Weapon.CooldownTime > 0.5f)
            {
                _player.Weapon.CooldownTime -= 0.2f;
                return true;
            }
            else
                return false;
        }

        public bool UpgradeWeaponHeatLimit()
        {
            if (_player.TotalScore >= 500 && _player.Weapon.HeatLimit < 30)
            {
                _player.Weapon.HeatLimit += 2;
                return true;
            }
            else
                return false;
        }


        public bool UpgradeShieldCapacity()
        {
            if (_player.TotalScore >= 100 && _player.Shield.MaxHitPoints < 500)
            {
                _player.Shield.MaxHitPoints += 50;
                return true;
            }
            else
                return false;
        }


        public bool UpgradeShieldRecoveryDelay()
        {
            if (_player.TotalScore >= 350 && _player.Shield.RecoveryDelay > 1.2f)
            {
                _player.Shield.RecoveryDelay -= 0.2f;
                return true;
            }
            else
                return false;
        }


        public bool UpgradeShieldRecoveryTime()
        {
            if (_player.TotalScore >= 50 && _player.Shield.RecoveryTime > 0.02f)
            {
                _player.Shield.RecoveryTime -= 0.01f;
                return true;
            }
            else
                return false;
        }
    }
}
