using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterListBL();
        void WriterAddBL(Writer item);
        void WriterDeleteBL(Writer item);
        void WriterUpdateBL(Writer item);
        Writer GetWriterByIdBL(int writerId);
        Writer GetWriterBL(Writer item);
        Writer GetWriterByEmailBL(string email);
    }
}
