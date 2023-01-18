using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Linq;

namespace ZooShop.Data.Validators
{
    class AmountValidator : AbstractValidator<Product>
    {
        public AmountValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Заполните поле количества").GreaterThan(0).WithMessage("ошибка ввода количества");

        }
    }
}
