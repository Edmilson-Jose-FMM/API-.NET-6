using FluentValidation;
using MP.ApiDotNet6.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Application.Validation
{
    public class ProductDTOValidation : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidation()
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Preço deve ser informado!");
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado!");
            
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Codigo deve ser informado!");



        }
    }
}
