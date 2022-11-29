using Api.Data;
using Api.Data.Dtos.User;
using Api.Entities.Exceptions;
using Api.Models;
using FluentValidation;

namespace Api.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        private AppDbContext _appDbContext;

        public UserValidator(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public UserValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MinimumLength(6).Equal(x => x.Email)
                .WithMessage("Campo username inválido!");

            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(70)
                .WithMessage("Campo Nome inválido!");

            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(70)
                .WithMessage("Campo sobrenome inválido");

            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.Password).NotNull().NotEmpty().Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])")
               .WithMessage("A senha deve conter letras maíusculas e minusculas, número e caracteres especiais");
        }

        public bool UnregisteredEmail(string email)
        {
            User user_ = _appDbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user_ != null) throw new ExistsEmailException("E-mail já existente"); 

            return true;
        }

    }
}
