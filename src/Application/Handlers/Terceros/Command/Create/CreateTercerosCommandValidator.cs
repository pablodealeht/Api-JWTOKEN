using FluentValidation;

namespace Application.Handlers.Terceros.Command.Create;

public class CreateTercerosCommandValidator : AbstractValidator<CreateTercerosCommand>
{
    public CreateTercerosCommandValidator()
    {
        RuleFor(x => x.SiniestroId)
            .NotEmpty();

        RuleFor(x => x.Nombre)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Apellido)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Tipo)
            .NotEmpty();

        RuleFor(x => x.Dni)
            .NotEmpty();
    }
}
