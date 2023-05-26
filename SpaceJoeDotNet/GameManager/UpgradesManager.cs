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
                    && upgrade.UpgradeAction.Invoke(_player))
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
                (player) =>
                {
                    if (player.Weapon.Damage < 280)
                    {
                        player.Weapon.Damage += 35;
                        return true;
                    }
                    return false;
                }),
                new Upgrade("Weapon Cooldown Time", 500,
                (player) =>
                {
                    if (player.Weapon.CooldownTime > 0.5f)
                    {
                        player.Weapon.CooldownTime -= 0.2f;
                        return true;
                    }
                    return false;
                }),
                new Upgrade("Weapon Heat Limit", 600,
                (player) =>
                {
                    if (player.Weapon.HeatLimit < 25)
                    {
                        player.Weapon.HeatLimit += 1;
                        return true;
                    }
                    return false;
                }),
                new Upgrade("Shield Capacity", 350,
                (player) =>
                {
                    if (player.Shield.MaxHitPoints < 300)
                    {
                        player.Shield.MaxHitPoints += 20;
                        return true;
                    }
                    return false;
                }),
                new Upgrade("Shield Recovery Delay", 450,
                (player) =>
                {
                    if (player.Shield.RecoveryDelay > 1.2f)
                    {
                        player.Shield.RecoveryDelay -= 0.4f;
                        return true;
                    }
                    return false;
                }),
                new Upgrade("Shield Recovery Time", 250,
                (player) =>
                {
                    if (player.Shield.RecoveryTime > 0.02f)
                    {
                        player.Shield.RecoveryTime -= 0.01f;
                        return true;
                    }
                    return false;
                }),
            };
        }
    }
}
