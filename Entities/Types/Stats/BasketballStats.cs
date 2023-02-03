using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Types
{
    public class BasketballStats : Stats
    {
        public decimal ScoredPoints { get; set; }
        public decimal Rebounds { get; set; }
        public decimal Assists { get; set; }
    }
}
