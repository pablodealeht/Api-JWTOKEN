using FluentValidation;

namespace Application.Handlers.Siniestros.Commands.Create;

public class CreateSiniestroCommandValidator : AbstractValidator<CreateSiniestroCommand>
{
    public CreateSiniestroCommandValidator()
    {
        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Direccion)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Localidad)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Provincia)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Pais)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Tipo)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("El tipo de siniestro seleccionado no es válido.");

        RuleFor(x => x.Fecha)
           .Must(date => date <= DateTime.Now)
           .WithMessage("La fecha no puede ser mayor a la fecha actual.");
    }
}