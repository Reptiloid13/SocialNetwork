using SocialNetwork.BusinessLogicLayer.Models;
using SocialNetwork.BusinessLogicLayer.Services;
using SocialNetwork.PresentationLogicLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PresentationLogicLayer.Views;

public class RegistrationView
{
    UserService userService;
    public RegistrationView(UserService userService)
    {
        this.userService = userService;
    }
    public void Show()
    {
        var userRegistrationData = new UserRegistrationData();

        Console.WriteLine("Для создания нового профиля введите ваше имя:");
        userRegistrationData.FirstName = Console.ReadLine();

        Console.Write("Ваша фамилия:");
        userRegistrationData.LastName = Console.ReadLine();

        Console.Write("Пароль:");
        userRegistrationData.Password = Console.ReadLine();

        Console.Write("Почтовый адрес:");
        userRegistrationData.Email = Console.ReadLine();

        try
        {
            this.userService.Register(userRegistrationData);
            SuccessMessages.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");

        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение.");
        }
        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при регистрации.");
        }

    }

}
