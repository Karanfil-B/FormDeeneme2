using Nw.Busines.Abstract;
using Nw.DataAcces.Abstract;
using Nw.DataAcces.Concrete;
using Nw.DataAcces.Concrete.EntityFramework;
using Nw.Entitiess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nw.Busines.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDall _productDal;
        public ProductManager(IProductDall productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
           return _productDal.GetAll();

        }
        public List<Product> GetByProductsName(string productSearchkey)
        {
            return _productDal.GetAll(k => k.ProductName.Contains(productSearchkey));
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        List<Product> IProductService.GetProductByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }
    }
}
