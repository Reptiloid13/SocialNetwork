using SocialNetwork.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PresentationLogicLayer.Views;

public class UserOutcommingMessageView
{
    public void Show(IEnumerable<Message> outcominMessages)
    {
        Console.WriteLine("Исходящие сообщения");
        if (outcominMessages.Count() == 0)
        {
            Console.WriteLine("Исходящих сообщений нет");
            return;
        }
        outcominMessages.ToList().ForEach(message =>
        {
            Console.WriteLine("Кому: {0}. Текст сообщения: {1}", message.RecipientEmail, message.Content);
        });
    }
}
