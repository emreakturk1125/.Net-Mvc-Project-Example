using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContactListBL();
        void ContactAddBL(Contact item);
        Contact GetContactByIdBL(int id);
        void ContactDeleteBL(Contact item);
        void ContactUpdateBL(Contact item);
    }
}
