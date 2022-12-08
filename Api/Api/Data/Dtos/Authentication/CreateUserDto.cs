using Api.Data.Daos;
using Api.Entities.Exceptions;
using Api.Models.Authentication;
using FluentValidation;

namespace Api.Data.Dtos.Authentication
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateUserDto()
        {
        }

        public CreateUserDto(string userName, string firstName, string lastName, string email, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }

    #region Validator
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        private UserDao _dao;

        public UserValidator(UserDao dao)
        {
            _dao = dao;
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
            User user_ = _dao.getUserByEmail(email);
            if (user_ != null) throw new ExistsEmailException("E-mail já existente");

            return true;
        }

    }

    #endregion
}
