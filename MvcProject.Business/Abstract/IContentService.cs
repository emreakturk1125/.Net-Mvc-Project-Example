using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentListBL();
        List<Content> GetContentListByHeadingIdBL(int id);
        void ContentAddBL(Content item);
        Content GetContentByIdBL(int id);
        void ContentDeleteBL(Content item);
        void ContentUpdateBL(Content item);
    }
}
