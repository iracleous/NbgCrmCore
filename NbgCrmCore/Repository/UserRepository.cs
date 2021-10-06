using Microsoft.EntityFrameworkCore;
using NbgCrmCore.Model;
using NbgCrmCore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CrmDbContext db;

        public UserRepository(CrmDbContext _db)
        {
            db = _db;
        }

        public DbResponse<User> CreateEntity(User t)
        {
            if (t.UserId != 0) t.UserId = 0;
            db.Users.Add(t);
            db.SaveChanges();
            return new DbResponse<User> { 
                ReturnCode = 0, 
                ReturnData = t, 
                ReturnDescription = "OK"
            };
        }

        public ICollection<Basket> GetBaskets(int userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool HardDeleteEntity(int id)
        {
            User user = db.Users.Find(id);
            if (user == null) return false;
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public ICollection<User> RetreiveEntities(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 5;
            return db.Users.Skip((pageNumber-1)* pageSize).Take(pageSize).ToList();
        }

        public DbResponse<User> RetreiveEntity(int id)
        {
            User user = db.Users.Where(p=>p.UserId==id).Include( user =>user.Baskets).First();
            return new DbResponse<User>
            {
                ReturnCode = 0,
                ReturnData = user,
                ReturnDescription = "OK"
            };
        }

        public bool SoftDeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public DbResponse<User> UpdateEntity(User t, int id)
        {
            User user = db.Users.Find(id);
            if (user==null)
            {
                return new DbResponse<User>
                {
                    ReturnCode = 400,
                     ReturnData =null,
                     ReturnDescription="No such user"

                };
            }
            user.FirstName = t.FirstName;
            user.LastName = t.LastName;
            user.Email = t.Email;
            user.Address = t.Address;
            user.Password = t.Password;
            user.Username = t.Username;

            db.SaveChanges();

            return new DbResponse<User>
            {
                ReturnCode = 200,
                ReturnData = user,
                ReturnDescription = "OK"

            };


        }
    }
}
