using Microsoft.Xna.Framework;
using SpaceJoeDotNet.GameManager;
using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpaceJoeDotNet.Tests
{
    public class AlienManagerTests
    {
        [Fact]
        public void Update_ShouldRemoveDestroyedAliens()
        {
            var am = new AlienManager();
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 0)) { HitPoints = 10 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 0)) { HitPoints = -4 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 0)) { HitPoints = 0 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 0)) { HitPoints = 1 });
            am.UpdateAliens(new GameTime(), 100, 100);

            Assert.Equal(2, am.Aliens.Count);
        }

        [Fact]
        public void Update_ShouldRemoveOffscreenAliens()
        {
            var am = new AlienManager();
            for (int i = 0; i < 15; i++)
                am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 0)) { HitPoints = 10 });

            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 250)) { HitPoints = 10 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 150)) { HitPoints = 10 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 101)) { HitPoints = 10 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, 201)) { HitPoints = 10 });
            am.Aliens.Add(new Alien(new DummyProjectileManager(), new Vector2(0, -30)) { HitPoints = 10 });
            am.UpdateAliens(new GameTime(), 100, 100);

            Assert.Equal(18, am.Aliens.Count);
        }
    }
}
