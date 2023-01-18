using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Data.Validators
{
    class WorkerValidator : AbstractValidator<Worker>
    {
        public WorkerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Заполните поле Имени");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Заполните поле Фамилии");
            RuleFor(x => x.Patranomyc).NotEmpty().WithMessage("Заполните поле Отчества");
            RuleFor(x => x.Position).NotEmpty().WithMessage("Заполните поле Должности");
        }
    }
}
