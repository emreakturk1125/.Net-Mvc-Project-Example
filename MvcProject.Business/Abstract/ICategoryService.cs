using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryListBL();
        void CategoryAddBL(Category item);
        Category GetCategoryByIdBL(int id);
        Category GetCategoryByNameBL(string name);
        void CategoryDeleteBL(Category item);
        void CategoryUpdateBL(Category item);
    }
}
