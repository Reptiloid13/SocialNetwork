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

public class AddingFriendView
{
    UserService userService;
    public AddingFriendView(UserService userService)
    {
        this.userService = userService;
    }
    public void Show(User user)
    {
        try
        {
            var userAddingFriendData = new UserAddingFriendData();
            Console.WriteLine("Введите почтовый адрес пользователя которого хотите добавить в друзья: ");

            userAddingFriendData.FriendEmail = Console.ReadLine();
            userAddingFriendData.UserId = user.Id;
            this.userService.AddFriend(userAddingFriendData);
            SuccessMessages.Show("Вы успешно добавили пользователя в друзья!");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователя с указанным почтовым адресом не существует!");

        }
        catch (Exception)
        {
            AlertMessage.Show("Произоша ошибка при добавлении пользотваеля в друзья!");
        }
    }
}
