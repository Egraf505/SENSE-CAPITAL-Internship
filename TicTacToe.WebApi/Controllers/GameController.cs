using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TicTacToe.Domain;
using TicTacToe.Persistence.Contex;

namespace TicTacToe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private GameContex _context;

        public GameController(GameContex contex)
        {
            _context = contex;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame(int userId)
        {
            if (!_context.Users.Any(user => user.Id == userId))
                return BadRequest("User not found");

            if (_context.GameTables.Any(table => (table.twoO.Id == userId || table.oneX.Id == userId) && table.finished == false))
                return BadRequest("the player is already playing");

            GameTable table = await _context.GameTables.FirstOrDefaultAsync(table => table.twoO.Id == null);

            if (table == null)
            {
                table = new GameTable();

                table.oneX.Id = userId;

                await _context.GameTables.AddAsync(table);
                await _context.SaveChangesAsync();
                
                return Ok(table.Id);
            }

            table.twoO.Id = userId;

            await _context.SaveChangesAsync();

            return Ok(table.Id);
            
        }
    }
}
