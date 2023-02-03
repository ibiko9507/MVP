using Entities.Constants;
using Entities.Enums;
using Entities.Types;
using Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    public class HandballMatchOperation
    {
        CommonOperation commonOperation = new CommonOperation();
        ValidationOperation validationOperation = new ValidationOperation();

        public List<Stats> CalculateHandballGamePoints(List<Stats> stats)
        {
            Match match = new Match();

            string[] teams = commonOperation.GetTeams(stats);
            match.FirstTeamTotalScore = FindHandballTeamScore(stats, teams[0]);
            match.SecondTeamTotalScore = FindHandballTeamScore(stats, teams[1]);

            if (match.FirstTeamTotalScore > match.SecondTeamTotalScore)
            {
                IterateTotalHandballPoints(ref stats, teams[0], GameType.HANDBALL);
            }
            else
            {
                IterateTotalHandballPoints(ref stats, teams[1], GameType.HANDBALL);
            }

            return stats.FindAll(f => stats.Max(m => m.TotalPoints) == f.TotalPoints);
        }

        private void IterateTotalHandballPoints(ref List<Stats> stats, string teamName, GameType gameType)
        {
            HandballStats handballStat;

            stats.ForEach(stat =>
            {
                handballStat = (HandballStats)stat;
                if (stat.TeamName == teamName)
                {
                    stat.TotalPoints = TotalHandballPoints(handballStat, Results.Win);
                }
                else
                {
                    stat.TotalPoints = TotalHandballPoints(handballStat, Results.Defeat);
                }
            });
        }

        public decimal TotalHandballPoints(HandballStats handballStats, Results result)
        {
            decimal totalPoints = 0;
            decimal pointsForWinning = result == Results.Win ? MatchConstants.PointsForWinning : 0;
            switch (handballStats.Position._position)
            {
                case HandballPosition.GoalKeeper:
                    totalPoints = handballStats.GoalsMade * 5
                    + handballStats.GoalsReceived * (-2)
                    + pointsForWinning
                    + HandballConstants.InitialGoalKeeperPoints;
                    break;
                case HandballPosition.FieldPlayer:
                    totalPoints = handballStats.GoalsMade * 1
                    + handballStats.GoalsReceived * (-1)
                    + pointsForWinning
                    + HandballConstants.InitialGoalFieldPlayerPoints;
                    break;
            }

            return totalPoints;
        }

        private decimal FindHandballTeamScore(List<Stats> stats, string team)
        {
            return stats.Where(w => w.TeamName == team).Select(s => ((HandballStats)s).GoalsMade).Sum();
        }
    }
}