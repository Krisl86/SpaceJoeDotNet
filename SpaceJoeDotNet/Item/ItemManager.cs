using System.Collections.Generic;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Item;

static class ItemManager
{
    public static List<Weapon> Weapons = new()
    {
        new Weapon("Old Rusty Laser", "Old Rusty", "It ain't much but it ain't much.",
            30, 5, 1.8f, ProjectileType.Default, 5)
    };
}