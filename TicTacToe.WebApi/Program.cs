using Microsoft.EntityFrameworkCore;
using TicTacToe.Persistence.Contex;
using TicTacToe.WebApi.Hubs;

namespace TicTacToe.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<GameContex>(options =>
                options.UseNpgsql());

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHub<GameHub>("/game");
            });

            app.Run();
        }
    }
}