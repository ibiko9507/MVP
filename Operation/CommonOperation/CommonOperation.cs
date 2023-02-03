
using Entities.Constants;
using Entities.Enums;
using Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    public class CommonOperation
    {
        public string[] SplitGameStats(string gameStats)
        {
            return gameStats.Split(Environment.NewLine);
        }

        public string[] SplitPlayerStats(string playerStats)
        {
            return playerStats.Split(CommonContants.SemiColon);
        }

        public GameType FindGameType(string gameType)
        {
            switch (gameType)
            {
                case MatchConstants.BASKETBALL:
                    return GameType.BASKETBALL;
                case MatchConstants.HANDBALL:
                    return GameType.HANDBALL;
            }

            return GameType.NONE;
        }

        public BasketballPosition FindBasketballPosition(string position)
        {
            switch (position)
            {
                case BasketballPositionConstants.Guard:
                    return BasketballPosition.Guard;
                case BasketballPositionConstants.Center:
                    return BasketballPosition.Center;
                case BasketballPositionConstants.Forward:
                    return BasketballPosition.Forward;
            }

            return BasketballPosition.None;
        }

        public HandballPosition FindHandballPosition(string position)
        {
            switch (position)
            {
                case HandballPositionConstants.GoalKeeper:
                    return HandballPosition.GoalKeeper;
                case HandballPositionConstants.FieldPlayer:
                    return HandballPosition.FieldPlayer;
            }

            return HandballPosition.None;
        }

        public string[] GetTeams(List<Stats> stats)
        {
            return stats.Select(s => s.TeamName).Distinct().ToArray();
        }

        public List<Stats> ConvertInputDataToGameObject(string[] gameStats, GameType gameType)
        {
            try
            {
                switch (gameType)
                {
                    case GameType.BASKETBALL:
                        return ConvertInputDataToBasketballObject(gameStats);
                    case GameType.HANDBALL:
                        return ConvertInputDataToHandballObject(gameStats);
                    default:
                        return null;
                }
            }
            catch
            {
                throw new Exception(ValidationMessages.BasketballGameStatFormatInvalid);
            }
        }

        private List<Stats> ConvertInputDataToBasketballObject(string[] gameStats)
        {
            try
            {
                List<Stats> stats = new List<Stats>();

                BasketballStats basketballStats;
                foreach (string gameStat in gameStats)
                {
                    if (gameStat == MatchConstants.BASKETBALL)
                    {
                        continue;
                    }

                    basketballStats = new BasketballStats();
                    string[] playerStats = SplitPlayerStats(gameStat);

                    basketballStats.PlayerName = playerStats[0];
                    basketballStats.NickName = playerStats[1];
                    basketballStats.Number = Convert.ToInt16(playerStats[2]);
                    basketballStats.TeamName = playerStats[3];
                    basketballStats.Position = new Position(GameType.BASKETBALL);
                    basketballStats.Position._position = FindBasketballPosition(playerStats[4]);
                    basketballStats.ScoredPoints = Convert.ToDecimal(playerStats[5]);
                    basketballStats.Rebounds = Convert.ToDecimal(playerStats[6]);
                    basketballStats.Assists = Convert.ToDecimal(playerStats[7]);

                    Stats stat = (Stats)basketballStats;
                    stats.Add(stat);
                }

                return stats;
            }
            catch
            {
                throw new Exception(ValidationMessages.BasketballGameStatFormatInvalid);
            }
        }

        private List<Stats> ConvertInputDataToHandballObject(string[] gameStats)
        {
            try
            {
                List<Stats> stats = new List<Stats>();

                HandballStats handballStats;
                foreach (string gameStat in gameStats)
                {
                    if (gameStat == MatchConstants.HANDBALL)
                    {
                        continue;
                    }

                    handballStats = new HandballStats();
                    string[] playerStats = SplitPlayerStats(gameStat);

                    handballStats.PlayerName = playerStats[0];
                    handballStats.NickName = playerStats[1];
                    handballStats.Number = Convert.ToInt16(playerStats[2]);
                    handballStats.TeamName = playerStats[3];
                    handballStats.Position = new Position(GameType.HANDBALL);
                    handballStats.Position._position = FindHandballPosition(playerStats[4]);
                    handballStats.GoalsMade = Convert.ToDecimal(playerStats[5]);
                    handballStats.GoalsReceived = Convert.ToDecimal(playerStats[6]);

                    Stats stat = (Stats)handballStats;
                    stats.Add(stat);
                }

                return stats;
            }
            catch
            {
                throw new Exception(ValidationMessages.HandballGameStatFormatInvalid);
            }
        }
    }
}
