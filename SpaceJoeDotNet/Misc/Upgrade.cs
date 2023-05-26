using SpaceJoeDotNet.GameObject;
using System;

namespace SpaceJoeDotNet.Misc
{
    class Upgrade
    {

        public Upgrade(string name, int price, Func<Player, bool> upgradeAction)
        {
            Name = name;
            Price = price;
            UpgradeAction = upgradeAction;
        }

        public string Name { get; }
        public int Price { get; }
        public Func<Player, bool> UpgradeAction { get; }
    }
}
