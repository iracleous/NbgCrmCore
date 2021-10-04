using NbgCrmCore.Model;
using NbgCrmCore.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CrmDbContext db;

        public ProductRepository(CrmDbContext _db)
        {
            db = _db;
        }
        DbResponse<Product> IRepository<Product>.CreateEntity(Product t)
        {
            db.Products.Add(t);
            db.SaveChanges();
            return new DbResponse<Product> { ReturnData = t };
        }

        public  bool HardDeleteEntity(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                return false;
            db.Products.Remove(product);
            return true;
        }

        ICollection<Product> IRepository<Product>.RetreiveEntities(int pageNumber, int pageSize)
        {
            return db.Products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        DbResponse<Product> IRepository<Product>.RetreiveEntity(int id)
        {
            return new DbResponse<Product>
            {
                ReturnCode = 0,
                ReturnData = db.Products.Find(id),
                ReturnDescription = ""
            };
        }

        bool IRepository<Product>.SoftDeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        DbResponse<Product> IRepository<Product>.UpdateEntity(Product t, int id)
        {
            throw new NotImplementedException();
        }
    }
}
