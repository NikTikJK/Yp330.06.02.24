
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using excel.Classes;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Main
{
    public class Parser
    {
        static List<Class>? groups;

        [DllImport("stairway.dll", EntryPoint = ("parse"))]
        private static extern string Parse(string path, string target);

        static ITelegramBotClient bot = new TelegramBotClient("6482902496:AAGgyzjWQoLM1CypfcajuYQvQ0CMEjjCdm4");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                string mes = message?.Text?.ToLower().ToString()!;
                switch(mes)
                {
                    case "/start":
                        await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                        break;
                           
                        default:
                        

                        string ansewer = groups?[0].ToString()!;
                        await botClient.SendTextMessageAsync(message.Chat, ansewer);
                        break;
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        static void Main(String[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
            var res = Parse("./test.xlsx", "Группа");
            groups = JsonSerializer.Deserialize<List<Class>>(res)!;
            Console.WriteLine(groups);
        }
    }
    
        
        
}