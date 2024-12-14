using NUnit.Framework;
using System;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Entities;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.Test
{
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void FindByEmailMustFindRegisterAccount()
        {
            UserService userService = new UserService();
            var userRegistrationData = new UserRegistrationData();
            userRegistrationData.LastName = "Ôàìèëèÿ";
            userRegistrationData.FirstName = "Èìÿ";
            userRegistrationData.Email = "name@gmail.com";
            userRegistrationData.Password = "11111111";
            userService.Register(userRegistrationData);

            try
            {
                userService.FindByEmail(userRegistrationData.Email);
            }
            catch (UserNotFoundException)
            {
                Assert.Fail();
            }


        }


    }
}