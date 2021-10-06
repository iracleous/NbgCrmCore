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

        public Task<UserDto> AddUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
