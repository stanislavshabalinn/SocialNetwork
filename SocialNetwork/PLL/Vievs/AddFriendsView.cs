using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendsView
    {
        FriendAddService friendService;

        public AddFriendsView(FriendAddService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var addFriensdData = new AddFriendsData();

            Console.Write("Введите почтовый адрес друга: ");
            addFriensdData.FriendEmail = Console.ReadLine();
            addFriensdData.UserId = user.Id;

            try
            {
                friendService.AddFriend(addFriensdData);
                AddFriendMessage.Show("Друг успешно добавлен!");

            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Друг не найден!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Ошибка при добавлении в друзья!");
            }

        }

    }
}