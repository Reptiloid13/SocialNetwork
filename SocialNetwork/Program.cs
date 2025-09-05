using SocialNetwork.BusinessLogicLayer;
using SocialNetwork.BusinessLogicLayer.Models;
using SocialNetwork.BusinessLogicLayer.Services;
using SocialNetwork.PresentationLogicLayer.Views;

namespace SocialNetwork;

public class Program
{
    static MessageService messageService;
    static UserService userService;
    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendinView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutcommingMessageView userOutcommingMessageView;
    public static AddingFriendView addingFriendView;
    public static UserFriendView userFriendView;


 static void Main(string[] args)
    {
        userService = new UserService();
        messageService = new MessageService();

        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendinView = new MessageSendingView(messageService, userService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutcommingMessageView = new UserOutcommingMessageView();
        addingFriendView = new AddingFriendView(userService);
        userFriendView = new UserFriendView();

        while (true)
        {
            mainView.Show();
        }


        

    }
}



