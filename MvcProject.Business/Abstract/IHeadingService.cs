using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingListBL();
        void HeadingAddBL(Heading item);
        Heading GetbyIdBL(int id);
        void HeadingDelete(Heading item);
        void HeadingUpdate(Heading item);
    }
}
