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

        [HttpGet]
        public async Task<IActionResult> StartGame()
        {
           
            GameTable table = new GameTable();

            table.playArea = new int?[9];
            table.PlayerHod = true;

            await _context.GameTables.AddAsync(table);
            await _context.SaveChangesAsync();

            return Ok(new { TableId = table.Id });            
        }

        [HttpPost]     
        public async Task<IActionResult> Move([FromBody] MoveDTO moveDTO)
        {
            try 
            { 
                GameTable table = await _context.GameTables.FirstOrDefaultAsync(table => table.Id == moveDTO.tableId);

                if (table == null)
                    return NotFound(new { MessageError = "Table not Found" });

                if (table.finished)
                    return BadRequest(new { MessageError = "Game is Finished" });
            
                if (table.playArea[moveDTO.position] != null)
                    return BadRequest(new { MessageError = "The field is not empty" });

                string message = "";

            
                if (table.PlayerHod)
                {
                    table.playArea[moveDTO.position] = 1;
                    table.PlayerHod = !table.PlayerHod;
                    message = $"Inserting X into position {moveDTO.position}";
                }
                else
                {
                    table.playArea[moveDTO.position] = 0;
                    table.PlayerHod = !table.PlayerHod;
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
                        return StatusCode(405, new { MessageError = "Raw enumeration" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { MessageError = ex.Message });
            }
        }

        private void FinishGame(GameTable table)
        {
            table.finished = true;
            _context.SaveChanges();
        }

        private ResultGameEnum CheckOfFinalsGame(int?[] matrix)
        {
            try
            {
                // columns

                for (int i = 0; i < 9; i += 3)
                {
                    int? result = matrix[i] + matrix[i + 1] + matrix[i + 2];

                    if (result == 3)
                    {
                        return ResultGameEnum.X;
                    }

                    if (result == 0)
                    {
                        return ResultGameEnum.O;
                    }
                }

                //rows

                for (int i = 0; i < 3; i++)
                {
                    int? result = matrix[i] + matrix[i + 3] + matrix[i + 6];

                    if (result == 3)
                    {
                        return ResultGameEnum.X;
                    }

                    if (result == 0)
                    {
                        return ResultGameEnum.O;
                    }
                }

                // first diagonal               

                if (matrix[0] + matrix[4] + matrix[8] == 3)
                {
                    return ResultGameEnum.X;
                }

                if (matrix[0] + matrix[4] + matrix[8] == 0)
                {
                    return ResultGameEnum.O;
                }

                // second diagonal          

                if (matrix[0] + matrix[4] + matrix[8] == 3)
                {
                    return ResultGameEnum.X;
                }

                if (matrix[0] + matrix[4] + matrix[8] == 0)
                {
                    return ResultGameEnum.O;
                }

                // Draw

                bool isNotNull = true;

                for (int i = 0; i < 9; i++)
                {
                    if (matrix[i] == null)
                    {
                        isNotNull = false;
                    }                    
                }

                if (isNotNull)
                {
                    return ResultGameEnum.Draw;
                }
                else
                {
                    return ResultGameEnum.NotFinished;
                }

            }
            catch (NullReferenceException)
            {
                return ResultGameEnum.NotFinished;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ResultGameEnum.NotFinished;
            }
        }
    }
}
