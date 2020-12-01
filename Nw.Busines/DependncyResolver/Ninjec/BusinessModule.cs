using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using System.Threading.Tasks;
using Nw.Busines.Abstract;
using Nw.Busines.Concrete;
using Nw.DataAcces.Abstract;
using Nw.DataAcces.Concrete.EntityFramework;

namespace Nw.Busines.DependncyResolver.Ninjec
{
    public class BusinessModule :NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDall>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
        }
    }
}
