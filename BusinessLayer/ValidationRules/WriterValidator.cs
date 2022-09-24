﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soy Adını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter giriş yapın!");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("En az 2 karakter giriş yapın!");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("50 karakterden fazla değer girişi yapmayın");
            

        }
    }
}
