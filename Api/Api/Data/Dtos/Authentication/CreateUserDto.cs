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
            RuleFor(x => x.UserName).NotNull().WithMessage("UserName é obrigatório")
                .NotEmpty().WithMessage("UserName é obrigatório")
                .MinimumLength(6)
                .Equal(x => x.Email).WithMessage("Campo username inválido!");

            RuleFor(x => x.FirstName).NotNull().WithMessage("O nome é obrigatório")
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres")
                .MaximumLength(70).WithMessage("O nome deve ter no máximo 70 caracteres");

            RuleFor(x => x.LastName).NotNull().WithMessage("O sobrenome é obrigatório")
                .NotEmpty().WithMessage("O sobrenome é obrigatório")
                .MinimumLength(3).WithMessage("O sobrenome deve ter no mínimo 3 caracteres")
                .MaximumLength(70).WithMessage("O sobrenome deve ter no máximo 70 caracteres");

            RuleFor(x => x.Email).NotNull().WithMessage("O e-mail é obrigatório")
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.Password).NotNull().WithMessage("A senha é obrigatória")
                .NotEmpty().WithMessage("A senha é obrigatória").Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])")
               .WithMessage("A senha deve conter letras maíusculas e minusculas, número e caracteres especiais");
        }

        public bool UnregisteredEmail(string email)
        {
            User user_ = _dao.getUserByEmail(email);
            if (user_ != null) throw new ExistsEmailException("E-mail já cadastrado!");

            return true;
        }

    }

    #endregion
}
