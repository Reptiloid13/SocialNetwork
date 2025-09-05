using SocialNetwork.BusinessLogicLayer;
using SocialNetwork.BusinessLogicLayer.Models;
using SocialNetwork.BusinessLogicLayer.Services;
using SocialNetwork.PresentationLogicLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PresentationLogicLayer.Views;

public class MessageSendingView
{
    UserService userService;
    MessageService messageService;
    public MessageSendingView(MessageService messageService, UserService userService)
    {
        this.messageService = messageService;
        this.userService = userService;
    }
    public void Show(User user)
    {
        var messageSendingData = new MessageSendingData();

        Console.Write("Введите почтовый адрес получателя: ");
        messageSendingData.RecipientEmail = Console.ReadLine();

        Console.WriteLine("Введите сообщение (не больше 5000 символов): ");
        messageSendingData.Content = Console.ReadLine();

        messageSendingData.SenderId = user.Id;
        try
        {
            messageService.SendMessage(messageSendingData);
            SuccessMessages.Show("Сообщение успешно отправлено!");
            user = userService.FindById(user.Id);
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }
        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при отправке сообщения!");
        }

    }
    
}
