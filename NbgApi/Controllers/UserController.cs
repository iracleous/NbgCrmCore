﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbgCrmCore.Model;
using NbgCrmCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        

        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        // localhost/user/1/2
        [HttpGet("{pageNumber}/{pageSize}")]
        public IEnumerable<User> Get(int pageNumber, int pageSize)
        {
            return _userRepository.RetreiveEntities(pageNumber, pageSize).ToList();
        }

        // localhost/user
        [HttpGet()]
        public IEnumerable<User> Get()
        {
            return _userRepository.RetreiveEntities(1, 5).ToList();
        }

        // localhost/user/1
        [HttpGet("{userId}")]
        public User Get(int userId)
        {
            return _userRepository.RetreiveEntity(userId).ReturnData;
        }

        // localhost/user
        [HttpPost]
        public User Create(User user)
        {
          return  _userRepository.CreateEntity(user).ReturnData;
        }
    }
}
