using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Dtos
{
    public class UserDto
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }



        public User GetUser()
        {
            return new User
            {
                UserId = UserId,
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Email = Email,
                Address = Address
            };

        }

        public UserDto() { }
        public UserDto(User user) {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Email = user.Email;
            Address = user.Address;
        }

    }
}
