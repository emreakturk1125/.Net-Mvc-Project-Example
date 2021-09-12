using FluentValidation;
using MvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.ValidationRules
{
    public class AdminValidator :  AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("Admin Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifreyi Boş Geçemezsiniz");
        }
    }
}
