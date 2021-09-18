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
        List<Content> GetContentListByWriterIdBL(int writerId);
        List<Content> GetContentListByHeadingIdBL(int headingId);
        void ContentAddBL(Content item);
        Content GetContentByIdBL(int contentId);
        void ContentDeleteBL(Content item);
        void ContentUpdateBL(Content item);
    }
}
