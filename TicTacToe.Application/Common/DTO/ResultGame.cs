using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Application.Common.Enums;

namespace TicTacToe.Application.Common.DTO
{
    public class ResultGame
    {
        public ResultGameEnum resultGame { get; set; }
        public string Message { get; set; } 
    }
}
