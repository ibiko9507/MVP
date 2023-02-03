using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Types
{
    public class Player
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public BasketballPosition Position { get; set; }
        public string TeamName { get; set; }
    }
}
