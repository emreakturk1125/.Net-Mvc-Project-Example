using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IAdminService
    {

        List<Admin> GetAdminListBL();
        void AdminAddBL(Admin item);
        Admin GetAdminBL(Admin item);
        void AdminDeleteBL(Admin item);
        void AdminUpdateBL(Admin item);
    }
}
