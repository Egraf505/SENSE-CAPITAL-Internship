using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TicTacToe.Application.Common.DTO;
using TicTacToe.Application.Common.Enums;
using TicTacToe.Domain;
using TicTacToe.Persistence.Contex;
using TicTacToe.WebApi.Hubs;

namespace TicTacToe.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private GameContex _context;

        public GameController(GameContex contex)
        {
            _context = contex;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame()
        {
           
            GameTable table = new GameTable();

            table.playArea = new int?[9];
            table.Hod = -1;

            await _context.GameTables.AddAsync(table);
            await _context.SaveChangesAsync();

            return Ok(table.Id);            
        }

        [HttpPost]     
        public async Task<IActionResult> Move([FromBody] MoveDTO moveDTO)
        {

            GameTable table = await _context.GameTables.FirstOrDefaultAsync(table => table.Id == moveDTO.tableId);

            if (table == null)
                return NotFound("Table not Found");

            if (table.finished)
                return Forbid("Game is Finished");
            
            if (table.playArea[moveDTO.p] != null)
                return BadRequest("the field is not empty");

            string message = "";

            if (table.Hod < 0)
            {
                table.playArea[moveDTO.p] = 1;
                message = $"Inserting X into position {moveDTO.p}";
            }

            if (table.Hod > 0)
            {
                table.playArea[moveDTO.p] = 0;
                message = $"Inserting O into position {moveDTO.p}";
            }

            await _context.SaveChangesAsync();

            switch (CheckOfFinalsGame(table.playArea))
            {
                case ResultGameEnum.NotFinished:                   
                    Console.WriteLine(message);
                    return StatusCode(210, message);                   

                case ResultGameEnum.Draw:
                    return StatusCode(211, "Draw");
                    
                case ResultGameEnum.X:
                    FinishGame(table);
                    return StatusCode(212, "X win");
                  

                case ResultGameEnum.O:
                    FinishGame(table);
                    return StatusCode(213, "O win");

                default:
                    return StatusCode(405, "raw enumeration");
            }        
        }

        private void FinishGame(GameTable table)
        {
            table.finished = true;
            _context.SaveChanges();
        }

        private ResultGameEnum CheckOfFinalsGame(int?[] matrix)
        {
            return ResultGameEnum.NotFinished;
        }
    }
}
