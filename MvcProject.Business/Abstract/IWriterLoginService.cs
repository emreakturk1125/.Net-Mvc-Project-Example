﻿using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IWriterLoginService
    {
        Writer GetWriterBL(string username, string password);
    }
}
