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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void ContactAddBL(Contact item)
        {
            _contactDal.Insert(item);
        }

        public void ContactDeleteBL(Contact item)
        {
            _contactDal.Delete(item);
        }

        public void ContactUpdateBL(Contact item)
        {
            _contactDal.Update(item);
        }

        public Contact GetContactByIdBL(int id)
        {
           return _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetContactListBL()
        {
            return _contactDal.List();
        }
    }
}
