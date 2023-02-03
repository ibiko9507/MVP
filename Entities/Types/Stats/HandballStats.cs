using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Types
{
    public class HandballStats : Stats
    {
        public decimal GoalsMade { get; set; }
        public decimal GoalsReceived { get; set; }
    }
}
