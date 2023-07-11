using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceJoeDotNet.Misc.Interfaces.Score
{
    interface ITracksScore
    {
        int TotalScore { get; set; }
        int Score { get; set; }
    }
}
