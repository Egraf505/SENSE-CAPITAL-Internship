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
            try 
            { 
                GameTable table = await _context.GameTables.FirstOrDefaultAsync(table => table.Id == moveDTO.tableId);

                if (table == null)
                    return NotFound("Table not Found");

                if (table.finished)
                    return BadRequest("Game is Finished");
            
                if (table.playArea[moveDTO.position] != null)
                    return BadRequest("The field is not empty");

                string message = "";

            
                if (table.Hod < 0)
                {
                    table.playArea[moveDTO.position] = 1;
                    table.Hod *= -1;
                    message = $"Inserting X into position {moveDTO.position}";
                }
                else
                {
                    table.playArea[moveDTO.position] = 0;
                    table.Hod *= -1;
                    message = $"Inserting O into position {moveDTO.position}";
                }

                await _context.SaveChangesAsync();                      

                ResultGame resultGame = new ResultGame();

                switch (CheckOfFinalsGame(table.playArea))
                {
                    case ResultGameEnum.NotFinished:
                        resultGame.resultGame = ResultGameEnum.NotFinished;
                        resultGame.Message = message;                  
                        return Ok(resultGame);                   

                    case ResultGameEnum.Draw:
                        resultGame.resultGame = ResultGameEnum.Draw;
                        resultGame.Message = "Draw";
                        FinishGame(table);
                        return Ok(resultGame);
                    
                    case ResultGameEnum.X:
                        resultGame.resultGame = ResultGameEnum.X;
                        resultGame.Message = "X win";
                        FinishGame(table);
                        return Ok(resultGame);
                  
                    case ResultGameEnum.O:
                        resultGame.resultGame = ResultGameEnum.O;
                        resultGame.Message = "O win";
                        FinishGame(table);
                        return Ok(resultGame);

                    default:
                        return StatusCode(405, "Raw enumeration");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
