using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace EHMSaver.Modules
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient discord;
        private readonly CommandService commands;
        private readonly IConfigurationRoot config;
        private readonly IServiceProvider provider;

        public CommandHandler(
            DiscordSocketClient dis,
            CommandService com,
            IConfigurationRoot conf,
            IServiceProvider prov)
        {
            discord = dis;
            commands = com;
            config = conf;
            provider = prov;

            discord.MessageReceived += OnMessageReceivedAsync;
        }

        private async Task OnMessageReceivedAsync(SocketChannelMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            if (msg.Author.Id == discord.CurrentUser.Id) return;

            var context = new SocketCommandContext(discord, msg);

            int argPos = 0;
            if (msg.HasStringPrefix(config["prefix"], ref argPos) || msg.HasMentionPrefix(discord.CurrentUser, ref argPos))
            {
                var result = await commands.ExecuteAsync(context, argPos, provider);

                if (!result.IsSuccess)
                    await context.Channel.SendMessageAsync(result.ToString());
            }
        }
    }
}
