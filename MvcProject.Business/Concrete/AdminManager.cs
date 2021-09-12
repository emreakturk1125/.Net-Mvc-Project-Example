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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public Admin GetAdminBL(Admin item)
        {
            return _adminDal.Get(x => x.AdminUsername == item.AdminUsername && x.AdminPassword == item.AdminPassword);
        }

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAddBL(Admin item)
        {
            throw new NotImplementedException();
        }

        public void AdminDeleteBL(Admin item)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdateBL(Admin item)
        {
            throw new NotImplementedException();
        }
         
        public List<Admin> GetAdminListBL()
        {
            return _adminDal.List();
        }
    }
}
