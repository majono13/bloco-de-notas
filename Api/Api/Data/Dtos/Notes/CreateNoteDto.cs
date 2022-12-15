using FluentValidation;

namespace Api.Data.Dtos.Notes
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string ?Content { get; set; }
        public bool IsFiled { get; set; }
        public int UserId { get; set; }
    }

    public class NoteValidator : AbstractValidator<CreateNoteDto>
    {
        public NoteValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Titulo é obrigatório")
                .NotEmpty().WithMessage("Titulo é obrigatório")
                .MinimumLength(3).WithMessage("Titulo deve ter no mínimo 3 caracteres")
                .MaximumLength(150).WithMessage("Titulo deve ter no máximo 150 caracteres");

            RuleFor(x => x.Content).MaximumLength(1000).WithMessage("A descrição deve ter no máximo 1000 caracteres");

            RuleFor(x => x.IsFiled).NotNull().WithMessage("Informe o status da nota");

            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}
