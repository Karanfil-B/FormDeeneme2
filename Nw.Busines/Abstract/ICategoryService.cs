using Nw.Entitiess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nw.Busines.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
     }
}
