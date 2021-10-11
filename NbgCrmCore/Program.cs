using NbgCrmCore.Model;
using NbgCrmCore.Repository;
using System;

namespace NbgCrmCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Test2();
        }


        static void Test2()
        {
            using var db = new CrmDbContext();
            UserRepository userRepository = new UserRepository(db);
            var users = userRepository.RetreiveEntities(0, 0);
            foreach(var user in users)
            {
                Console.WriteLine($" userId = {user.UserId}  email= {user.Email}");
            }
        }
        static void Test1()
        {
            User user = new User()
            {
                Address = "Lamia",
                Email = "a@a.gr",
                FirstName = "Dimos",
                LastName = "Nikolaou",
                Password = "123456",
                Username = "Dimos"
            };
            using var db = new CrmDbContext() ;
            UserRepository userRepository = new UserRepository( db);
            var response = userRepository.CreateEntity(user);
            Console.WriteLine($"userId = {response.ReturnData.UserId}");
        }
    }
}
