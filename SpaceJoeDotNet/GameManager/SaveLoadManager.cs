using SpaceJoeDotNet.GameObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.GameManager
{
    class SaveLoadManager
    {
        public bool SaveFileExists => File.Exists(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "SpaceJoeGameSaves\\save.txt"));

        public void Save(Player player)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
                "SpaceJoeGameSaves");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using var sw = new StreamWriter(Path.Combine(path, "save.txt"));
            
            sw.WriteLine(player.TotalScore);
            sw.WriteLine(player.Weapon.Damage);
            sw.WriteLine(player.Weapon.CooldownTime);
            sw.WriteLine(player.Weapon.HeatLimit);
            sw.WriteLine(player.Shield.MaxHitPoints);
            sw.WriteLine(player.Shield.RecoveryTime);
            sw.WriteLine(player.Shield.RecoveryDelay);
        }

        public bool Load(ref Player player)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
               "SpaceJoeGameSaves");

            if (!SaveFileExists)
                return false;

            using var sr = new StreamReader(Path.Combine(path, "save.txt"));
            bool loadSuccessful = false;

#nullable disable
            try
            {
                player.TotalScore = int.Parse(sr.ReadLine());
                player.Weapon.Damage = int.Parse(sr.ReadLine());
                player.Weapon.CooldownTime = int.Parse(sr.ReadLine());
                player.Weapon.HeatLimit = int.Parse(sr.ReadLine());
                player.Shield.MaxHitPoints = int.Parse(sr.ReadLine());
                player.Shield.RecoveryTime = int.Parse(sr.ReadLine());
                player.Shield.RecoveryDelay = int.Parse(sr.ReadLine());
                loadSuccessful = true;
            }
            catch { }
#nullable enable

            return loadSuccessful;
        }
    }
}
