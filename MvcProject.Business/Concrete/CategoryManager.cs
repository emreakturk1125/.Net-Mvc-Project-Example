using MvcProject.Business.Abstract;
using MvcProject.DataAccess.Abstract;
using MvcProject.DataAccess.Concrete.Repositories;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category item)
        {
            _categoryDal.Insert(item);
        }

        public void CategoryDeleteBL(Category item)
        {
            _categoryDal.Delete(item);
        }

        public void CategoryUpdateBL(Category item)
        {
            _categoryDal.Update(item);
        }

        public Category GetCategoryByIdBL(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public Category GetCategoryByNameBL(string name)
        {
            return _categoryDal.Get(x => x.CategoryName.ToLower() == name.ToLower());
        }

        public List<Category> GetCategoryListBL()
        {
            return _categoryDal.List();
        }
    }
}
 