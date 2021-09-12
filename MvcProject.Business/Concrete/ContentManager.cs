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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content item)
        {
            throw new NotImplementedException();
        }

        public void ContentDeleteBL(Content item)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdateBL(Content item)
        {
            throw new NotImplementedException();
        }

        public Content GetContentByIdBL(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentListBL()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentListByHeadingIdBL(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }
    }
}
