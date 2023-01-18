using FluentValidation;
using System.Linq;

namespace ZooShop.Data.Validators
{
    class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            //x => string.IsNullOrEmpty(MainWindow.DB.User.FirstOrDefault(y => y.Login == x.User.Login).Login) == true
            RuleFor(x => x.Login).NotEmpty().WithMessage("Заполните поле логина").Must(BeAValidLogin).WithMessage("Такой логин уже существует").MinimumLength(3).WithMessage("Логин должен состоять хотя-бы из 3 символов");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Заполните поле пароля").MinimumLength(6).WithMessage("Пороль должен состоять хотя-бы из 6 символов");

        }

        private bool BeAValidLogin(string login) 
        {
            return (DbConnection.DB.Account.FirstOrDefault(y => y.Login == login) == null);
        }
    }
}
