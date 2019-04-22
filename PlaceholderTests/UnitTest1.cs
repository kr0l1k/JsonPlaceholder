using JsonPlaceholder.Models;
using System;
using Xunit;

namespace PlaceholderTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            string email = "test@test.ru";
            var user = new User();

            
            user.Id = 1;
            user.Name = "Alex Petrov";
            user.Phone = "+7939393";
            user.Username = "Alex p";
            user.Website = "erwwr";
            user.Email = email;
            // Act
            var  user1 = JsonPlaceholder.Managers.Crypt.EncryptUser(ref user);
            user1 = JsonPlaceholder.Managers.Crypt.DecryptUser(ref user1);
            Assert.Equal(user.Email, user1.Email);
        }
    }
}
