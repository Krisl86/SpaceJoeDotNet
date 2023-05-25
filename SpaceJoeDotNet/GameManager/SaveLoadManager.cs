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
        public string SpaceJoeDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "SpaceJoeGameSaves");
        public string SaveFilePath => Path.Combine(SpaceJoeDir, "savegame.txt");
        public string HighScoreFilePath => Path.Combine(SpaceJoeDir, "highscore.txt");

        public bool SaveFileExists => File.Exists(SaveFilePath);
        public bool HighScoreFileExists => File.Exists(HighScoreFilePath);

        public void Save(Player player)
        {
            if (!Directory.Exists(SpaceJoeDir))
                Directory.CreateDirectory(SpaceJoeDir);

            using var sw = new StreamWriter(SaveFilePath);
            
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
            if (!SaveFileExists)
                return false;

            using var sr = new StreamReader(SaveFilePath);
            bool loadSuccessful = false;

#nullable disable
            try
            {
                player.TotalScore = int.Parse(sr.ReadLine());
                player.Weapon.Damage = int.Parse(sr.ReadLine());
                player.Weapon.CooldownTime = float.Parse(sr.ReadLine());
                player.Weapon.HeatLimit = int.Parse(sr.ReadLine());
                player.Shield.MaxHitPoints = int.Parse(sr.ReadLine());
                player.Shield.RecoveryTime = float.Parse(sr.ReadLine());
                player.Shield.RecoveryDelay = float.Parse(sr.ReadLine());
                loadSuccessful = true;
            }
            catch { }
#nullable enable

            return loadSuccessful;
        }

        public void SaveHighScore(Dictionary<int, string> highscores)
        {
            if (!Directory.Exists(SpaceJoeDir))
                Directory.CreateDirectory(SpaceJoeDir);

            using var sw = new StreamWriter(HighScoreFilePath);
            foreach (var kvp in highscores)
            {
                sw.WriteLine(kvp.Key);
                sw.WriteLine(kvp.Value);
            }
        }

        public bool LoadHighScore(ref Dictionary<int, DateTime> highscores)
        {
            if (!HighScoreFileExists)
                return false;

            bool loadSuccessful = false;
            highscores.Clear();
            string[] lines = File.ReadAllLines(HighScoreFilePath);

            try
            {
                for (int i = 0; i < lines.Length - 1; i += 2)
                {
                    highscores.Add(int.Parse(lines[i]), DateTime.Parse(lines[i + 1]));
                }
                loadSuccessful = true;
            }
            catch { }

            return loadSuccessful;
        }
    }
}
