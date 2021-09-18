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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetHeadingByIdBL(int headingId)
        {
            return _headingDal.Get(x => x.HeadingId == headingId);
        }

        public List<Heading> GetHeadingListBL()
        {
           return  _headingDal.List();
        }

        public List<Heading> GetHeadingListByWriterIdBL(int writerId)
        {
            return _headingDal.List(x => x.WriterId == writerId && x.HeadingStatus == true);
        }

        public void HeadingAddBL(Heading item)
        {
            _headingDal.Insert(item);
        }

        public void HeadingDelete(Heading item)
        {
            _headingDal.Update(item);
        }

        public void HeadingUpdate(Heading item)
        {
            _headingDal.Update(item);
        }
    }
}
