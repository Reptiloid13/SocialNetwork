using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PresentationLogicLayer.Views;

public class UserIncomingMessageView
{
    public void Show(IEnumerable<Message> intcomingMessage)
    {
        Console.WriteLine("Входящие сообщения");
        if (intcomingMessage.Count() == 0)
        {
            Console.WriteLine("Входящих сообщения нет");
            return;
        }
        intcomingMessage.ToList().ForEach(message => Console.WriteLine("От кого: {0}. Текст сообщения: {1}", message.SenderEmail, message.Content));
    }
    
}
