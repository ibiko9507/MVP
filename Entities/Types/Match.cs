using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Types
{
    public class Match
    {
        public int Id { get; set; }
        public GameType GameType { get; set; }
        public decimal FirstTeamTotalScore { get; set; }
        public decimal SecondTeamTotalScore { get; set; }
    }
}
