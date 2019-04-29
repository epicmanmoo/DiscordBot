﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Linq;
using System.Collections.Generic;

namespace botTesting
{
    class Program : ModuleBase<SocketCommandContext>
    {

        private DiscordSocketClient Client;
        private CommandService Commands;
        public static List<string> JoinMsgList = new List<string>();
        public static List<string> LeaveMsgList = new List<string>();
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug,
                MessageCacheSize = 1000
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            Client.Ready += Client_Ready;
            Commands.CommandExecuted += Commands_CommandExecutedAsync;
            Client.UserJoined += AnnounceJoinedUser;
            Client.Log += Client_Log;
            Client.UserLeft += AnnounceLeavingUser;
            string Token = "NTY1MDQ4OTY5MjA2NjkzODg4.XK432A.z3Bcq5ZOsN9L_vErrmGW8hFryA8";
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
            await Task.Delay(-1);
            using (var DbContext = new SQLiteDBContext())
            {
                if (DbContext.Stones.Where(x => x.UserId == 519689963562991651).Count() < 1)
                {
                    DbContext.Add(new Stone
                    {
                        UserId = 519689963562991651,
                        Amount = 0,
                        Warnings = 0,
                        Item1 = 0,
                        Item2 = 0,
                        Item3 = 0,
                        Item4 = 0,
                        Item5 = 0,
                        Item6 = 0,
                        Item7 = 0,
                        Item8 = 0,
                        Item9 = 0,
                        Item10 = 0
                    });
                    await DbContext.SaveChangesAsync();
                }
            }
        }

     
        private async Task Commands_CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (result.Error.Equals(CommandError.ParseFailed))
            {
                await context.Channel.SendMessageAsync("Go back and reread how to loop dumbass");
            }

            else if (result.Error.Equals(CommandError.ObjectNotFound))
            {
                await context.Channel.SendMessageAsync("That user doesn't exist dumbass");  
            }
            else if (result.Error.Equals(CommandError.BadArgCount))
            {
                //error for this type
            }
            //etc errors...
        }

        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

        private async Task Client_Ready()
        {
            await Client.SetGameAsync("with your feelings");

        }

        public async Task AnnounceJoinedUser(SocketGuildUser User)
        {
            //567602259102531594
            var channel = Client.GetChannel(565413968643096578) as SocketTextChannel;           
            Random Random = new Random();
            int Rand = Random.Next(JoinMsgList.Count);
            await channel.SendMessageAsync($"{User.Mention} has joined! " + JoinMsgList[Rand]); 
            using (var DbContext = new SQLiteDBContext())
            {
                DbContext.Add(new Stone
                {
                    UserId = User.Id,
                    Amount = 0,
                    Warnings = 0,
                    Item1 = 0,
                    Item2= 0,
                    Item3= 0,
                    Item4= 0,
                    Item5= 0,
                    Item6= 0,
                    Item7= 0,
                    Item8= 0,
                    Item9= 0,
                    Item10= 0,

                });
                await DbContext.SaveChangesAsync();
            }
        }
        
        public async Task AnnounceLeavingUser(SocketGuildUser User)
        {
            var Channel = Client.GetChannel(567604758106472448) as SocketTextChannel;
            //await Channel.SendMessageAsync($"{User} has left");
            using (var DbContext = new SQLiteDBContext())
            {
                Stone Stone = DbContext.Stones.Where(x => x.UserId == User.Id).FirstOrDefault();
                DbContext.Remove(Stone);
                await DbContext.SaveChangesAsync();
            }
        }

        private async Task Client_MessageReceived(SocketMessage MessageParam)
        {
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);
            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.Username.Equals("myBot")) return;
            int ArgPos = 0;
            if (!(Message.HasStringPrefix("!", ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;
            var Result = await Commands.ExecuteAsync(Context, ArgPos, null);
            if (!Result.IsSuccess)
            {
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
            }

        }
    }
}
