using Nw.Entitiess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nw.Busines.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetProductByCategory(int categoryId);
        List<Product> GetByProductsName(string productSearchkey);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
