using SocialNetwork.BusinessLogicLayer.Models;
using SocialNetwork.BusinessLogicLayer.Services;
using SocialNetwork.PresentationLogicLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PresentationLogicLayer.Views;

public class UserDataUpdateView
{
    UserService userService;
    public UserDataUpdateView(UserService userService)
    {
        this.userService = userService;
    }
    public void Show(User user)
    {
        Console.Write("Меня зовут:");
        user.FirstName = Console.ReadLine();

        Console.Write("Моя фамилия:");
        user.LastName = Console.ReadLine();

        Console.Write("Ссылка на моё фото:");
        user.Photo = Console.ReadLine();

        Console.Write("Мой любимый фильм:");
        user.FavoriteMovie = Console.ReadLine();

        Console.Write("Моя любимая книга:");
        user.FavoriteBook = Console.ReadLine();

        this.userService.Update(user);

        SuccessMessages.Show("Ваш профиль успешно обновлён!");
    }
}
