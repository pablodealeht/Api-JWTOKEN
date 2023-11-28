using FluentValidation;

namespace Application.Handlers.Personal.Commands.Create
{
    public class CreatePersonalCommandValidator : AbstractValidator<CreatePersonalCommand>
    {
        public CreatePersonalCommandValidator()
        {

            RuleFor(x => x.registerType)
           .NotEmpty()
           .MaximumLength(200);
  
        }
    }
}
