using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Entities.Types
{
    public class Stats
    {
        public string PlayerName { get; set; }
        public string NickName { get; set; }
        public short Number { get; set; }
        public string TeamName { get; set; }
        public Position Position { get; set; }
        public decimal TotalPoints { get; set; }
        
    }
}
