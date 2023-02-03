using Entities.Constants;
using Entities.Enums;
using Entities.Types;
using Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    public class MatchOperation
    {
        #region definitions
        CommonOperation commonOperation = new CommonOperation();
        ValidationOperation validationOperation = new ValidationOperation();
        BasketballMatchOperation basketballMatchOperation = new BasketballMatchOperation();
        HandballMatchOperation handballMatchOperation = new HandballMatchOperation();
        string myDirectory = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.ToString() + "\\TestData\\";
        #endregion definitions

        public string[] SplitGameStats(string gameStats)
        {
            return commonOperation.SplitGameStats(gameStats);
        }

        public void EvaluateGame(string textFile, out string validationResult)
        {
            string gameStats = String.Empty;
            try
            {
                textFile = myDirectory + textFile;
                using (var sr = new StreamReader(textFile, Encoding.UTF8))
                {
                    gameStats = sr.ReadToEnd();
                }
            }
            catch
            {
                validationResult = ValidationMessages.InputFileTypesInvalid;
                return;
            }
            

            #region General Validations

            if (!validationOperation.ValidateGameInput(textFile, gameStats, out validationResult))
            {
                return;
            }

            string[] playerStats = SplitGameStats(gameStats);
            GameType gameType = commonOperation.FindGameType(playerStats.First()); //Finding what kind of game is it

            List<Stats> stats = commonOperation.ConvertInputDataToGameObject(playerStats, gameType);

            if (!validationOperation.ValidateGameInputDetailed(gameType,stats, out validationResult))
            {
                return;
            }

            #endregion General Validations


            List<Stats> mvpPlayers = CalculatePoints(stats, gameType);

            ShowMvpPlayer(mvpPlayers);
        }

        public void ShowMvpPlayer(List<Stats> mvpPlayers)
        {
            Console.WriteLine(CreateMvpMessage(mvpPlayers));
        }

        private static string CreateMvpMessage(List<Stats> mvpPlayers)
        {
            string mvpPlayerList = String.Empty;
            string playerInfo = String.Empty;
            MatchMessages matchMessages = new MatchMessages();
            mvpPlayers.ForEach(f =>
            {
                playerInfo += String.Format(MatchConstants.MvpPlayerNameAndNumber, f.PlayerName, f.Number);
            });
            mvpPlayerList += String.Format(matchMessages.TheMvpPlayers, playerInfo);
            string mvpPlayerTotalPoints = String.Format(MatchConstants.MvpPlayerTotalPoints, mvpPlayers[0].TotalPoints);
            string mvpPlayerMessage = String.Concat(mvpPlayerList, mvpPlayerTotalPoints);

            return mvpPlayerMessage;
        }

        private List<Stats> CalculatePoints(List<Stats> stats, GameType gameType)
        {
            switch (gameType)
            {
                case GameType.BASKETBALL:
                    return basketballMatchOperation.CalculateBasketballGamePoints(stats);
                case GameType.HANDBALL:
                    return handballMatchOperation.CalculateHandballGamePoints(stats);
            }
            return stats;
        }
    }
}