using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public class MatchConstants
    {
        public const string BASKETBALL = "BASKETBALL";
        public const string HANDBALL = "HANDBALL";
        public const string MvpPlayerTotalPoints = "Total Points: {0}";
        public const string MvpPlayerNameAndNumber = "NAME: {0} - " + "Number: {1} - ";
        public const decimal PointsForWinning = 10;
    }

    public class HandballConstants
    {
        public const decimal InitialGoalKeeperPoints = 50;
        public const decimal InitialGoalFieldPlayerPoints = 20;
    }
}
