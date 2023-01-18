using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Data.Validators
{
    class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Заполните поле цены").GreaterThan(0).WithMessage("ошибка ввода цены"); ;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Заполните поле Названии");

        }
    }
}
