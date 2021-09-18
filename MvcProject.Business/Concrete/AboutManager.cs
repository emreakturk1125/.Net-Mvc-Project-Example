using MvcProject.Business.Abstract;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAddBL(About item)
        {
            _aboutDal.Insert(item);
        }

        public void AboutDeleteBL(About item)
        {
            _aboutDal.Delete(item);
        }

        public void AboutUpdateBL(About item)
        {
            _aboutDal.Update(item);
        }

        public About GetAboutByIdBL(int aboutId)
        {
            return _aboutDal.Get(x => x.AboutId == aboutId);
        }

        public List<About> GetAboutListBL()
        {
            return _aboutDal.List();
        }
    }
}
