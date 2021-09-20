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
            throw new NotImplementedException();
        }

        public ICollection<User> RetreiveEntities(int pageNumber, int pageSize)
        {
            return db.Users.ToList();
        }

        public DbResponse<User> RetreiveEntity(int id)
        {
            User user = db.Users.Find(id);
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
            throw new NotImplementedException();
        }
    }
}
