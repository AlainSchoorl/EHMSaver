using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EHMSaver.Modules
{
    public class StartupService
    {
        private readonly DiscordSocketClient discord;
        private readonly CommandService commands;
        private readonly IConfigurationRoot config;

        public StartupService(
            DiscordSocketClient dis,
            CommandService com,
            IConfigurationRoot, conf)
        {
            config = config;
            discord = dis;
            commands = com;
        }

        public async Task StartAsync()
        {
            string discordToken = 
        }
    }
}
