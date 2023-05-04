using System.Collections.Generic;
using SpaceJoeDotNet.GameObject;

namespace SpaceJoeDotNet.Item;

static class ItemManager
{
    public static List<Weapon> Weapons = new()
    {
        new Weapon("Old Rusty Laser", "Old Rusty", "It ain't much but it ain't much.",
            30, 7, 1.4f, ProjectileType.Default, 5),
        new Weapon("Okay Laser", "OK Laser", "It can do something, but not much.",
            70, 12, 0.8f, ProjectileType.Default, 7),
        new Weapon("Pirate Laser", "Pirate Laser", "Used mainly by space pirates.",
            120, 20, 0.6f, ProjectileType.Fast, 4),
        new Weapon("Slow Laser of Slow But Sure Doom", "Slow Laser", "Slow to fire, high damage.",
            260, 3, 2f, ProjectileType.Slow, 12),
        new Weapon("Shiny New Military Grade F378-GD Capacitor Mass Field Laser", "Military Laser", "[encrypted].",
            9999, 12, 0.4f, ProjectileType.Fast, 9)
    };
}