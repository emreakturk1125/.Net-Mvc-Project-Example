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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetMessageByIdBL(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetMessageDraftListBL()
        {
            return _messageDal.List(x =>  x.IsDraft == true);
        }

        public List<Message> GetMessageInboxListBL()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com" && x.IsDraft == false);
        }

        public List<Message> GetMessageSendListBL()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == false);

        }

        public void MessageAddBL(Message item)
        {
            _messageDal.Insert(item);
        }

        public void MessageDeleteBL(Message item)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdateBL(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
