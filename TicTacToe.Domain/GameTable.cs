using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Domain
{
    public class GameTable
    {
        public int Id { get; set; }

        public bool PlayerHod { get; set; }

        public int?[] playArea { get; set; }

        public bool finished { get; set; }

    }
}
