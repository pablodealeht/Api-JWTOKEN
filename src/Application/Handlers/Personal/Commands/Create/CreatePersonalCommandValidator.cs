using Application.Handlers.Terceros.Command.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
