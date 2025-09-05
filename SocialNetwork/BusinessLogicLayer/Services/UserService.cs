using SocialNetwork.BusinessLogicLayer;
using SocialNetwork.BusinessLogicLayer.Models;
using SocialNetwork.DataAccessLayer.Entities;
using SocialNetwork.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BusinessLogicLayer.Services;

public class UserService
{
    MessageService messageService;
    IUserRepository userRepository;
    IFriendRepository friendRepository;
    public UserService()
    {
        userRepository = new UserRepository();
        friendRepository = new FriendRepository();
        messageService = new MessageService();
    }
    public void Register(UserRegistrationData userRegistrationData)
    {
        if (String.IsNullOrEmpty(userRegistrationData.FirstName))
            throw new ArgumentNullException();

        if (String.IsNullOrEmpty(userRegistrationData.LastName))
            throw new ArgumentNullException();

        if (String.IsNullOrEmpty(userRegistrationData.Password))
            throw new ArgumentNullException();

        if (String.IsNullOrEmpty(userRegistrationData.Email))
            throw new ArgumentNullException();

        if (userRegistrationData.Password.Length < 8)
            throw new ArgumentNullException();

        if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            throw new ArgumentNullException();

        if (userRepository.FindByEmail(userRegistrationData.Email) != null)
            throw new ArgumentNullException();

        var userEntity = new UserEntity()
        {
            firstName = userRegistrationData.FirstName,
            lastName = userRegistrationData.LastName,
            password = userRegistrationData.Password,
            email = userRegistrationData.Email
        };
        if (this.userRepository.Create(userEntity) == 0)
            throw new Exception();

    }
    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
        if (findUserEntity is null) throw new UserNotFoundException();
        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();
        return ConstructUserModel(findUserEntity);
    }
    public User FindByEmail(string email)
    {
        var findUserEntity = userRepository.FindByEmail(email);
        if (findUserEntity is null) throw new UserNotFoundException();
        return ConstructUserModel(findUserEntity);
    }
    public User FindById(int id)
    {
        var findUserEntity = userRepository.FindById(id);
        if (findUserEntity is null) throw new UserNotFoundException();
        return ConstructUserModel(findUserEntity);
    }
    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstName = user.FirstName,
            lastName = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favorite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };
        if (this.userRepository.Update(updatableUserEntity) == 0)
            throw new Exception();
    }
    public IEnumerable<User>GetFriendByUserId(int userId)
    {
        return friendRepository.FindAllByUserId(userId)
            .Select(friendsEntity => FindById(friendsEntity.friend_id));
    }
    public void AddFriend(UserAddingFriendData userAddingFriendData)
    {
        var findUserEntity = userRepository.FindByEmail(userAddingFriendData.FriendEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var friendEntity = new FriendEntity()
        {
            user_id = userAddingFriendData.UserId,
            friend_id = findUserEntity.id
        };
        if (this.friendRepository.Create(friendEntity) == 0)
            throw new Exception();

    }
    private User ConstructUserModel(UserEntity userEntity)
    {
        var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
        var outgoingMessages = messageService.GetOutComingMessageByUserId(userEntity.id);
        var friends = GetFriendByUserId(userEntity.id);

        return new User(userEntity.id,
            userEntity.firstName,
            userEntity.lastName,
            userEntity.password,
            userEntity.email,
            userEntity.photo,
            userEntity.favorite_movie,
            userEntity.favorite_book,
           incomingMessages,
           outgoingMessages,
           friends);
    }
}
