using SpaceJoeDotNet.GameObject;
using System;

namespace SpaceJoeDotNet.Misc
{
    class Upgrade
    {

        public Upgrade(string name, int price, Func<bool> upgradeAction, Func<string> value)
        {
            Name = name;
            Price = price;
            UpgradeAction = upgradeAction;
            Value = value;
        }

        public string Name { get; }
        public int Price { get; }
        public Func<bool> UpgradeAction { get; }
        public Func<string> Value { get; }
    }
}
