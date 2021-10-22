using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbgApi.Dto;
using NbgCrmCore.Model;
using NbgCrmCore.Repository;
using NbgCrmCore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NbgApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public DbResponse<User> Get(int userId)
        {
            return _userRepository.RetreiveEntity(userId);
        }

        // localhost/user
        [HttpPost]
        public DbResponse<User> Create(User user)
        {
            return _userRepository.CreateEntity(user);
        }

        [HttpPut("{userId}")]
        public DbResponse<User> Update([FromRoute] int userId, [FromBody] User user)
        {
            return _userRepository.UpdateEntity(user, userId);
        }


        private const string SessionKeyUserCredentials = "UserCredentials";
 

        public string Login([FromBody]  CredentialsDto credentialsDto)
        {
            if ( string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserCredentials)))
            {
                //I assume that the user exists
                HttpContext.Session.SetString(SessionKeyUserCredentials,
                    JsonSerializer.Serialize(credentialsDto));
         
                return "You have been logged successfully";

            }

            CredentialsDto saveCredentials =
                JsonSerializer.Deserialize<CredentialsDto>
                (HttpContext.Session.GetString(SessionKeyUserCredentials));

            return "You have been already logged as "+ saveCredentials.UserName;

            
        }


    }
}
