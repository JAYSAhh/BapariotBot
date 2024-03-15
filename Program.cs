using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;



namespace BapariotBot
{
    class Program {


        private static string _token = "7100129405:AAHbnLz_-DD4_GDBtej2AC_gAeEsQ0nwxjU";
        private static TelegramBotClient _botClient;

        private static bool Receiving = false;

        static void Main(string[] args)
        {
           



            _botClient = new TelegramBotClient(_token);
           _botClient.StartReceiving(Update, Error);
           Console.WriteLine("Работа бота запущена");
           Console.ReadLine();
 


        }
        
    
    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if( message != null && message.Text != null)
            {
                Console.WriteLine($"[{message.Date}][{message.Chat.Type}] Новое сообщение от {message.From.Username} : {message.Text}");

                if (message.Text.ToLower().Contains("/команды"))
                {
                    Message botMessage = await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: $"Список команд 😎 \n \n /пинг \n /дэнс \n /кубик \n /пых \n /кольнёмс \n /кринж \n /кама \n /пнуть \n /трах \n /динаху \n /кто \n /шлеп",
                    replyToMessageId: message.MessageId,
                    disableNotification: false
               );
                }
                if (message.Text.ToLower().Contains("начать"))
                {
                    Message botMessage = await botClient.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: InputFile.FromUri("https://yastatic.net/avatars/get-grocery-goods/2998515/468edfb5-bdd1-48b6-bfc8-ef8364f6beb4/750x500?webp=true"),
                        caption: "Вы желаете , чтобы Маршал Бананчиков вступил в бой ?",
                        replyMarkup: new InlineKeyboardMarkup("sADadA")
                         ) ;
                                           
                }
                if (message.Text.ToLower().Contains("/пинг")) PingAll(_botClient, message);
                if (message.Text.ToLower().Contains("/онлайн")) CheckMembersOnline(_botClient, message);
                if (message.Text.ToLower().Contains("/дэнс"))
                {
                  if(message.ReplyToMessage == null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                       chatId: message.Chat.Id,
                       animation: InputFile.FromUri("https://www.youloveit.ru/uploads/gallery/main/464/my_little_ponyes_gif63.gif"),
                       caption: $"@{message.From.Username} люто дэнсит 😎🤩",
                       replyToMessageId: message.MessageId);

                    }
                    else
                    {
                       Message botMessage = await botClient.SendAnimationAsync(
                       chatId: message.Chat.Id,
                       animation: InputFile.FromUri("https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/2447f2fb-81df-4a6a-8c30-355b5a55c9f2/d4ia62q-5879cb53-c939-4b4c-8ce9-2d0a76609fcd.gif?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzI0NDdmMmZiLTgxZGYtNGE2YS04YzMwLTM1NWI1YTU1YzlmMlwvZDRpYTYycS01ODc5Y2I1My1jOTM5LTRiNGMtOGNlOS0yZDBhNzY2MDlmY2QuZ2lmIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.GqgvnTr9y9Lf0OwrtP90S_lt-EQPMHaN2j2OsiyLDfo"),
                       caption: $"@{message.From.Username} и @{message.ReplyToMessage.From.Username}  люто дэнсят , нормальные такие малыхи , счастливые наверное 😎🤩",
                       replyToMessageId: message.MessageId);
                    }

                }
                if (message.Text.ToLower().Contains("/кубик"))
                {
                    Random random = new Random();

                    Message botMessage = await botClient.SendAnimationAsync(chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media1.tenor.com/m/GS3glUNc6-YAAAAC/dice.gif"),
                        caption: $"@{message.From.Username} выкатывает шары и выкидывает {random.Next(1, 7)} 🎲🎲 "
                        );
                }
                if (message.Text.ToLower().Contains("/пых"))
                {

                    Message botMessage = await botClient.SendAnimationAsync(chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExYmwwdTJrc3ZkMDFvZjRkYjBxZTdlbmJvN2xlZDhkdXc3NDl3czJyMiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/wHB67Zkr63UP7RWJsj/giphy.gif"),
                        caption: $"@{message.From.Username} пыхает сижечку-движечку  🚬🤓"
                        );
                }
                if (message.Text.ToLower().Contains("/кольнёмс"))
                {

                    Message botMessage = await botClient.SendAnimationAsync(chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media2.giphy.com/media/4TgFeQBxcWB89uOI4y/giphy.gif?cid=6c09b952ctzbe0nomxvoib9dtuzclqeq2p31knaoax7kdh42&ep=v1_internal_gif_by_id&rid=giphy.gif&ct=g"),
                        caption: $"@{message.From.Username} делает прививку , какой молодец 🥵🥰"
                        );
                }
                if (message.Text.ToLower().Contains("/кринж"))
                {
                    if (message.ReplyToMessage == null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                       chatId: message.Chat.Id,
                       animation: InputFile.FromUri("https://gifdb.com/images/high/cute-yellow-chick-cringe-ny584weauoznxq41.gif"),
                       caption: $"@{message.From.Username} ловит кринж 💀",
                       replyToMessageId: message.MessageId);

                    }
                    else
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media.tenor.com/66rEdMvcNyQAAAAM/no-cringe.gif"),
                        caption: $"@{message.From.Username} ловит нереальную кринжару от @{message.ReplyToMessage.From.Username} 💀💀💀💀",
                        replyToMessageId: message.MessageId);
                    }

                }
                if (message.Text.ToLower().Contains("/кама"))
                {
                    if (message.ReplyToMessage == null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                       chatId: message.Chat.Id,
                       animation: InputFile.FromUri("https://media.tenor.com/P-dOrUIOsC0AAAAM/blow.gif"),
                       caption: $"@{message.From.Username} выливает каму 🥵",
                       replyToMessageId: message.MessageId);

                    }
                    else
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media.tenor.com/P-dOrUIOsC0AAAAM/blow.gif"),
                        caption: $"@{message.From.Username} выливает каму на @{message.ReplyToMessage.From.Username} ",
                        replyToMessageId: message.MessageId);
                    }

                }
                if (message.Text.ToLower().Contains("/пнуть"))
                {
                    if (message.ReplyToMessage == null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                       chatId: message.Chat.Id,
                       animation: InputFile.FromUri("https://img2.reactor.cc/pics/comment/%D0%B3%D0%B8%D1%84%D0%BA%D0%B8-%D1%81%D0%BE%D0%B1%D0%B0%D0%BA%D0%B0-4509250.gif"),
                       caption: $"@{message.From.Username} пинает сам себя 👺",
                       replyToMessageId: message.MessageId);

                    }
                    else
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media.tenor.com/IImn3WA3UosAAAAC/300-action.gif"),
                        caption: $"@{message.From.Username} пинает @{message.ReplyToMessage.From.Username} 👿👺",
                        replyToMessageId: message.MessageId);
                    }

                }
                if (message.Text.ToLower().Contains("/трах"))
                {
                    if (message.ReplyToMessage == null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                       chatId: message.Chat.Id,
                       animation: InputFile.FromUri("https://media4.giphy.com/media/nsuAkTMAhJ4SQ/giphy.gif"),
                       caption: $"@{message.From.Username} давит своего ковбоя 🥵🤨",
                       replyToMessageId: message.MessageId);

                    }
                    else
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://media.tenor.com/gs2Z4GPn12MAAAAM/cat-cute.gif"),
                        caption: $"@{message.From.Username} трахает сисю-писю @{message.ReplyToMessage.From.Username} 💋🥵👺",
                        replyToMessageId: message.MessageId);
                    }

                }
                if (message.Text.ToLower().Contains("/динаху"))
                {
                    if (message.ReplyToMessage != null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://steamuserimages-a.akamaihd.net/ugc/1014945137018365093/BC49787BED313C649F89EF1B825987B47B4449DC/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"),
                        caption: $"@{message.From.Username} посылает @{message.ReplyToMessage.From.Username} 🤬🤓",
                        replyToMessageId: message.MessageId);
                    }

                }
                if (message.Text.ToLower().StartsWith("/кто"))
                {
                    Random random = new Random();

                    if (message.Chat.Type != ChatType.Private)                   {

                        var members = await botClient.GetChatAdministratorsAsync(message.Chat.Id);


                        string action = message.Text;
                        action = action.Substring(4);
                        action = action.Trim();
                        Message botMessage = await botClient.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: $"Я думаю-с , что @{members[random.Next(0, members.Length)].User.Username} {action} 🔮"




                            );
                    }
                }
                if (message.Text.ToLower().Contains("/шлеп"))
                {
                    if (message.ReplyToMessage != null)
                    {
                        Message botMessage = await botClient.SendAnimationAsync(
                        chatId: message.Chat.Id,
                        animation: InputFile.FromUri("https://anime-chan.me/uploads/posts/2013-11/1385498275_anime-pancu-etti-anime-gifs-936742.gif"),
                        caption: $"@{message.From.Username} шлёпает @{message.ReplyToMessage.From.Username} 🥵🥰",
                        replyToMessageId: message.MessageId);
                    }

                }
            }
        }  

    private static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {

            Console.WriteLine($"Ошибка :{exception.Message}.Номер: {token.ToString()}");

            return null;
        }
    private static async void PingAll(TelegramBotClient botClient , Message message )
        {
            var members = await botClient.GetChatAdministratorsAsync(message.Chat.Id);
            string membersCall = "";

            foreach (ChatMember member in members)
            {
                membersCall += $"@{member.User.Username} ";
            }

            Message botMessage = await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Бананчики , сбор {membersCall}",
                replyToMessageId: message.MessageId,
                disableNotification:false
                ) ;


        }

        private static async void CheckMembersOnline(TelegramBotClient botClient, Message message )
        {
            var messages =  botClient.GetChatAsync(message.Chat.Id);
            
                
        }


    }

  
}
