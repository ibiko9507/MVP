using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public class ValidationMessages
    {
        public const string InvalidInput = "Invalid input";
        public const string GameStatsCanNotBeNull = "Game stats can not be null";
        public const string SplitStatDetailsBySemiColon = "Player stat details has to be splitted by Semicolons";
        public const string ThereAreNotEnoughPlayer = "There has to be at least two player in the game";
        public const string TeamCountIsInvalid = "There has to be two teams in the game";
        public const string GameTypeIsNotValid = "Game type is not valid. Currently valid types: 'BASKETBALL', 'HANDBALL'";
        public const string PlayerNickNamesHaveToBeUnique = "Player nick names have to be unique";
        public const string InputFileTypesInvalid = "File type is invalid input file type : 'txt'";
        public const string BasketballGameStatFormatInvalid = "Input stats are invalid. Valid blueprint should be like this: player name;nickname;number;team name;position;scored points;rebounds;assists";
        public const string HandballGameStatFormatInvalid = "Input stats are invalid. Valid blueprint should be like this: player name;nickname;number;team name;position;goals made;goals received";
        public const string PlayerCountOfTeamsAreDifferent = "Both teams must have the same player count";
    }
}
