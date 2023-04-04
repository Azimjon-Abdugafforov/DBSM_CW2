using DBSD_CW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBMS_CW_last.Repo
{
    public interface IProductsRepo
    {
        IList<Product> GetAll();
        IList<Product> Filter(string name, bool onSale, int categoryId, decimal price );
        void Insert(Product product);
        Product GetById(int Id);
        void Update(Product product);
        void Delete(int Id);
    
    
    }
}
