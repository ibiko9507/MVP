using Entities.Constants;
using Entities.Enums;
using Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Operation
{
    public class ValidationOperation
    {
        CommonOperation commonOperation = new CommonOperation();
        public bool ValidateGameInput(string textFile, string gameStats, out string validationResult)
        {
            validationResult = ValidateFileType(textFile);
            if (String.IsNullOrEmpty(validationResult) == false)
                return false;

            validationResult = ValidateGameInput(gameStats);
            return String.IsNullOrEmpty(validationResult);
        }

        public bool ValidateGameInputDetailed(GameType gameType, List<Stats> stats, out string validationResult)
        {
            validationResult = String.Empty;

            if (isGameTypeValid(gameType) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.GameTypeIsNotValid);
                return false;
            }

            if (teamCountIsValid(stats) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.TeamCountIsInvalid);
                return false;
            }

            if (playerCountOfTeamsAreEqual(stats) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.PlayerCountOfTeamsAreDifferent);
                return false;
            }

            if (playersAreUnique(stats) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.PlayerNickNamesHaveToBeUnique);
            }            

            return String.IsNullOrEmpty(validationResult);
        }

        public string ValidateGameInput(string gameStats)
        {
            String validationResult = String.Empty;
            if (isNullCheck(gameStats))
            {
                validationResult = AddValidation(validationResult, ValidationMessages.GameStatsCanNotBeNull);
            }

            if (semiColonExistsCheck(gameStats) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.SplitStatDetailsBySemiColon);
            }

            if (hasEnoughPlayer(gameStats) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.ThereAreNotEnoughPlayer);
            }

            return validationResult;
        }

        public string ValidateFileType(string textFile)
        {
            String validationResult = String.Empty;

            if (isValidFileType(textFile) == false)
            {
                validationResult = AddValidation(validationResult, ValidationMessages.InputFileTypesInvalid);
            }

            return validationResult;
        }

        private bool isValidFileType(string textFile)
        {
            string ext = Path.GetExtension(textFile).Replace(".", "");
            if (ext != CommonContants.ValidFileTypes)
            {
                return false;
            }
            return true;
        }

        private bool playersAreUnique(List<Stats> stats)// to get a better performance for the program, this function can be removed
        {
            List<string> players = new List<string>();
            foreach (Stats statsItem in stats)
            {
                if (players.Contains(statsItem.NickName))
                {
                    return false;
                }
                players.Add(statsItem.NickName);
            }

            return true;
        }

        private bool teamCountIsValid(List<Stats> stats)
        {
            string[] teams = commonOperation.GetTeams(stats);
            if (teams.Count() != 2)
            {
                return false;
            }
            return true;
        }

        private bool playerCountOfTeamsAreEqual(List<Stats> stats)
        {
            string[] teams = commonOperation.GetTeams(stats);
            if (stats.Count(c=>c.TeamName == teams[0]) != stats.Count(c => c.TeamName == teams[1])) //Equality control
            {
                return false;
            }
            return true;
        }

        private bool hasEnoughPlayer(string gameStats)
        {
            if (Regex.Matches(gameStats, Environment.NewLine).Count > 2)
            {
                return true;
            }

            return false;
        }

        private bool isNullCheck(string gameStats)
        {
            if (String.IsNullOrEmpty(gameStats))
            {
                return true;
            }

            return false;
        }

        private bool semiColonExistsCheck(string gameStats)
        {
            if (gameStats.Contains(CommonContants.SemiColon))
            {
                return true;
            }

            return false;
        }

        private bool isGameTypeValid(GameType gameType)
        {
            if (gameType != GameType.NONE)
            {
                return true;
            }

            return false;
        }

        public string AddValidation(string validationResult, string validation)
        {
            validationResult += Environment.NewLine + validation;
            return validationResult;
        }


    }
}
