using NbgCrmCore.Dtos;
using NbgCrmCore.Model;
using NbgCrmCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public UserDto AddUser(UserDto userDto)
        {
            User user = userDto.GetUser();
            userRepository.CreateEntity(user);
            return new UserDto(user);
        }
    }
}
