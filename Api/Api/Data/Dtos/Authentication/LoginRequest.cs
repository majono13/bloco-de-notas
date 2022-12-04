using FluentValidation;

namespace Api.Data.Dtos.Authentication
{
    public class LoginRequest 
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequest()
        {
        }

        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    #region validator
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {

        public LoginRequestValidator()
        {
            RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("O e-mail é obrigatório").EmailAddress().WithMessage("E-mail inválido");


            RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("A senha é obrigatória");

        }
    }

    #endregion
}
