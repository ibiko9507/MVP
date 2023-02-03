using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public class PositionConstants
    {

    }

    public class BasketballPositionConstants : PositionConstants
    {
        public const string Guard = "G";
        public const string Forward = "F";
        public const string Center = "C";
    }

    public class HandballPositionConstants : PositionConstants
    {
        public const string GoalKeeper = "G";
        public const string FieldPlayer = "F";
    }
}
