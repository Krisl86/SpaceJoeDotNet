using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Misc.Interfaces;

namespace SpaceJoeDotNet.Item.Interfaces
{
    internal interface IWeapon : IPositionedGameObject, ICanShoot
    {
        float CooldownTime { get; set; }
        int CurrentHeat { get; set; }
        int Damage { get; set; }
        int HeatLimit { get; set; }
    }
}