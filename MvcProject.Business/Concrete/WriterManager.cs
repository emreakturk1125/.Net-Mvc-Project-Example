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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriterByIdBL(int writerId)
        {
            return _writerDal.Get(x => x.WriterId == writerId);
        }

        public Writer GetWriterBL(Writer item)
        {
            return _writerDal.Get(x => x.WriterMail == item.WriterName && x.WriterPassword == item.WriterPassword);
        }

        public Writer GetWriterByEmailBL(string email)
        {
            return _writerDal.Get(x => x.WriterMail == email);
        }

        public List<Writer> GetWriterListBL()
        {
            return _writerDal.List();
        }

        public void WriterAddBL(Writer item)
        {
            _writerDal.Insert(item);
        }

        public void WriterDeleteBL(Writer item)
        {
            _writerDal.Delete(item);
        }

        public void WriterUpdateBL(Writer item)
        {
            _writerDal.Update(item);
        }
    }
}
