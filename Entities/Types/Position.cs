using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Types
{
    public class BasketballPositionType
    {
        public const int None = 0;
        public const int Guard = 1;
        public const int Forward = 2;
        public const int Center = 3;
    }

    public class HandballPositionType
    {
        public const int None = 0;
        public const int GoalKeeper = 1;
        public const int FieldPlayer = 2;
    }

    public class Position
    {
        public dynamic? _position;
        public Position(GameType gameType)
        {
            _position = null;
            switch (gameType)
            {
                case GameType.BASKETBALL:
                    _position = new BasketballPosition();
                    break;
                case GameType.HANDBALL:
                    _position = new HandballPosition();
                    break;
            }
        }
    }
}
