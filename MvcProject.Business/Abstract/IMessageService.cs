using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageInboxListBL();
        List<Message> GetMessageSendListBL();
        List<Message> GetMessageDraftListBL();
        void MessageAddBL(Message item);
        Message GetMessageByIdBL(int messageId);
        void MessageDeleteBL(Message item);
        void MessageUpdateBL(Message item);
    }
}
