using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class FriendAddService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendAddService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<User> GetFriendsUserById(int userid)
        {
            var userService = new UserService();
            return friendRepository.FindAllByUserId(userid)
                          .Select(friendsEntity => userService.FindById(friendsEntity.friend_id));
        }

        public void AddFriend(AddFriendsData addingFriendData)
        {
            var findUserEntity = this.userRepository.FindByEmail(addingFriendData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = addingFriendData.UserId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();

        }
    }
}