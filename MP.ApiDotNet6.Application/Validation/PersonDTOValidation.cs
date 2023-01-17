using FluentValidation;
using MP.ApiDotNet6.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Application.Validation
{
    public class PersonDTOValidation : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidation()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado!");
            RuleFor(x => x.Name)
              .NotEmpty()
              .NotNull()
              .WithMessage("Nome deve ser informado!");
            RuleFor(x => x.Phone)
              .NotEmpty()
              .NotNull()
              .WithMessage("Numero de telefone deve ser informado!");
           

        }

    }
}
