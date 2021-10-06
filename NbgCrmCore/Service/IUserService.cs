using NbgCrmCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
    public interface IUserService
    {
        public UserDto AddUser(UserDto userDto);
    }
}
