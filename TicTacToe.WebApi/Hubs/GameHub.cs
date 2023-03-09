using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using TicTacToe.Persistence.Contex;

namespace TicTacToe.WebApi.Hubs
{
    [Authorize]    
    public class GameHub : Hub
    {
        private GameContex _contex;

        public GameHub(GameContex contex)
        {
            _contex = contex;
        }

        public async Task Play(int userID)
        {
            
        }
    }
}
