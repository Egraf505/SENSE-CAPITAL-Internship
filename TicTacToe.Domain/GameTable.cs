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
        public User? oneX { get; set; }
        public User? twoO { get; set; }

        public bool? p0 { get; set; }
        public bool? p1 { get; set; }
        public bool? p2 { get; set; }
        public bool? p3 { get; set; }
        public bool? p4 { get; set; }
        public bool? p5 { get; set; }
        public bool? p6 { get; set; }
        public bool? p7 { get; set; }
        public bool? p8 { get; set; }

        public bool finished { get; set; }

    }
}
