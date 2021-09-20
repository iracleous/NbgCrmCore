using NbgCrmCore.Model;
using NbgCrmCore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public ICollection<Basket> GetBaskets(int userId, int pageNumber, int pageSize);
            
    }
}
