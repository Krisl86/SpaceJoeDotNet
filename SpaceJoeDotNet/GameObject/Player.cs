using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameCustomLibrary;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameManager.Interfaces;
using SpaceJoeDotNet.GameObject.Interfaces.GameObject;
using SpaceJoeDotNet.Item;
using SpaceJoeDotNet.Item.Interfaces;
using System;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceJoeDotNet.GameObject;

class Player : BaseSpaceJoeGameObject, IPlayer
{
    public Player(IProjectileManager projectileManager, IWeapon weapon, IShield shield)
    {
        (ProjectileManager, Weapon, Shield) = (projectileManager, weapon, shield);
    }

    public int HitPoints { get; set; }
    public int Damage { get; set; }
    public int TotalScore { get; set; }
    public int Score { get; set; }
    public IProjectileManager ProjectileManager { get; set; }
    public IWeapon Weapon { get; set; }
    public IShield Shield { get; set; }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Shoot(Vector2 direction)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public override void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}