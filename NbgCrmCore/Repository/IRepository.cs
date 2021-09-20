using NbgCrmCore.Model;
using NbgCrmCore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Repository
{
    public interface IRepository<T>
    {
        //CRUD

        public DbResponse<T> CreateEntity(T t);
        public ICollection<T> RetreiveEntities(int pageNumber, int pageSize);
        public DbResponse<T> RetreiveEntity(int id);
        public DbResponse<T> UpdateEntity(T t, int id);

        public bool SoftDeleteEntity(int id);
        public bool HardDeleteEntity(int id);
    }
}
