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
    public class BasketballMatchOperation
    {
        CommonOperation commonOperation = new CommonOperation();

        public List<Stats> CalculateBasketballGamePoints(List<Stats> stats)
        {
            Match match = new Match();

            string[] teams = commonOperation.GetTeams(stats);
            match.FirstTeamTotalScore = FindBasketballTeamScore(stats, teams[0]);
            match.SecondTeamTotalScore = FindBasketballTeamScore(stats, teams[1]);

            if (match.FirstTeamTotalScore > match.SecondTeamTotalScore)
            {
                IterateTotalBasketballPoints(ref stats, teams[0], GameType.BASKETBALL);
            }
            else
            {
                IterateTotalBasketballPoints(ref stats, teams[1], GameType.BASKETBALL);
            }

            return stats.FindAll(f => stats.Max(m => m.TotalPoints) == f.TotalPoints);
        }

        private void IterateTotalBasketballPoints(ref List<Stats> stats, string teamName, GameType gameType)
        {
            BasketballStats basketballStat;

            stats.ForEach(stat =>
            {
                basketballStat = (BasketballStats)stat;
                if (stat.TeamName == teamName)
                {
                    stat.TotalPoints = TotalBasketballPoints(basketballStat, Results.Win);
                }
                else
                {
                    stat.TotalPoints = TotalBasketballPoints(basketballStat, Results.Defeat);
                }
            });
        }

        public decimal TotalBasketballPoints(BasketballStats basketballStats, Results result)
        {
            decimal totalPoints = 0;
            decimal pointsForWinning = result == Results.Win ? MatchConstants.PointsForWinning : 0;

            switch (basketballStats.Position._position)
            {
                case BasketballPosition.Guard:
                    totalPoints = basketballStats.ScoredPoints * 2
                    + basketballStats.Rebounds * 3
                    + basketballStats.Assists * 1
                    + pointsForWinning;
                    break;
                case BasketballPosition.Forward:
                    totalPoints = basketballStats.ScoredPoints * 2
                    + basketballStats.Rebounds * 2
                    + basketballStats.Assists * 2
                    + pointsForWinning;
                    break;
                case BasketballPosition.Center:
                    totalPoints = basketballStats.ScoredPoints * 2
                    + basketballStats.Rebounds * 1
                    + basketballStats.Assists * 3
                    + pointsForWinning;
                    break;
            }

            return totalPoints;
        }

        private decimal FindBasketballTeamScore(List<Stats> stats, string team)
        {
            return stats.Where(w => w.TeamName == team).Select(s => ((BasketballStats)s).ScoredPoints).Sum();
        }
    }
}