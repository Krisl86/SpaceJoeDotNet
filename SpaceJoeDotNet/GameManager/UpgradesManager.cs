using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Misc;
using System.Collections.Generic;
using System.Linq;

namespace SpaceJoeDotNet.GameManager
{
    class UpgradesManager
    {
        Player _player;

        public UpgradesManager(Player player)
        {
            _player = player;
            InitUpgrades();
        }

        public List<Upgrade> Upgrades { get; private set; } = null!;

        public bool PurchaseUpgrade(int upgradeIndex)
        {
            if (Upgrades.ElementAtOrDefault(upgradeIndex) is Upgrade upgrade)
            {
                if (_player.TotalScore >= upgrade.Price
                    && upgrade.UpgradeAction.Invoke())
                {
                    _player.TotalScore -= upgrade.Price;
                    return true;
                }
            }
            return false;
        }

        void InitUpgrades()
        {
            Upgrades = new()
            {
                new Upgrade("Weapon Damage", 450,
                () =>
                {
                    if (_player.Weapon.Damage < 280)
                    {
                        _player.Weapon.Damage += 35;
                        return true;
                    }
                    return false;
                }, () => _player.Weapon.Damage.ToString()),
                new Upgrade("Weapon Cooldown Time", 500,
                () =>
                {
                    if (_player.Weapon.CooldownTime > 0.5f)
                    {
                        _player.Weapon.CooldownTime -= 0.2f;
                        return true;
                    }
                    return false;
                }, () => _player.Weapon.CooldownTime.ToString("0.00")),
                new Upgrade("Weapon Heat Limit", 600,
                () =>
                {
                    if (_player.Weapon.HeatLimit < 25)
                    {
                        _player.Weapon.HeatLimit += 1;
                        return true;
                    }
                    return false;
                }, () => _player.Weapon.HeatLimit.ToString()),
                new Upgrade("Shield Capacity", 350,
                () =>
                {
                    if (_player.Shield.MaxHitPoints < 300)
                    {
                        _player.Shield.MaxHitPoints += 20;
                        return true;
                    }
                    return false;
                }, () => _player.Shield.MaxHitPoints.ToString()),
                new Upgrade("Shield Recovery Delay", 450,
                () =>
                {
                    if (_player.Shield.RecoveryDelay > 1.2f)
                    {
                        _player.Shield.RecoveryDelay -= 0.4f;
                        return true;
                    }
                    return false;
                }, () => _player.Shield.RecoveryDelay.ToString("0.00")),
                new Upgrade("Shield Recovery Time", 250,
                () =>
                {
                    if (_player.Shield.RecoveryTime > 0.02f)
                    {
                        _player.Shield.RecoveryTime -= 0.01f;
                        return true;
                    }
                    return false;
                }, () => _player.Shield.RecoveryTime.ToString("0.00")),
            };
        }
    }
}
