using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.DataAccess.Abstract
{
    public interface IMessageDal : IRepository<Message>
    {
    }
}
