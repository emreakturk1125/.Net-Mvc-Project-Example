using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutListBL();
        void AboutAddBL(About item);
        About GetAboutByIdBL(int aboutId);
        void AboutDeleteBL(About item);
        void AboutUpdateBL(About item);
    }
}
