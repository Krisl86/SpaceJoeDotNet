using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using SpaceJoeDotNet.Misc;
using SpaceJoeDotNet.Tests.Dummy;
using Xunit;


namespace SpaceJoeDotNet.Tests
{
    public class UpgradesManagerTests
    {

        [Fact]
        public void PurchaseUpgrade_ShouldReturnFalseForNonExistingUpgrade()
        {
            var player = new Player(new DummyProjectileManager(), new Vector2(0, 0))
            { TotalScore = 99999999 };
            var um = new UpgradesManager(player);

            Assert.False(um.PurchaseUpgrade(9999));
            Assert.False(um.PurchaseUpgrade(-200));
        }

        [Fact]
        public void PurchaseUpgrade_ShouldReturnFalseIfPlayerDoesntHaveEnoughCredits()
        {
            var player = new Player(new DummyProjectileManager(), new Vector2(0, 0))
            { TotalScore = -100 };
            var um = new UpgradesManager(player);

            Assert.False(um.PurchaseUpgrade(1));
            Assert.False(um.PurchaseUpgrade(2));
        }

        [Fact]
        public void PurchaseUpgrade_ShouldDeductCorrectAmountOfCredits()
        {
            var player = new Player(new DummyProjectileManager(), new Vector2(0, 0))
            { TotalScore = 1000 };
            var um = new UpgradesManager(player);
            um.Upgrades.Add(new Upgrade("test", 100, () => 1 == 1, () => "testString"));
            um.PurchaseUpgrade(um.Upgrades.Count - 1);

            Assert.Equal(900, player.TotalScore);
        }
    }
}
