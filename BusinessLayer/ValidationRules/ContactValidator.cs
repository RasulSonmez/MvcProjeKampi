using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact> 
    {
        public ContactValidator ()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter giriş yapın!");
          
        }

    }
}
