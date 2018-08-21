using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace EHMSaver
{
    public class Program
    {
        public static void Main(string[] args)
                => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();
            //comment
            client.Log += Log;

            string token = System.IO.File.ReadAllText(@"X:\Users\Alain\source\repos\token.txt");
            await client.LoginAsync(Discord.TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }
    }
}