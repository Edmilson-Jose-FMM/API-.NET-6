using MP.ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }
        public Purchase(int productId, int personId, DateTime date)
        {
        }
        private void Validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId<0, "Nome deve ser informado");
            DomainValidationException.When(personId<0, "Documento deve ser informado");
            DomainValidationException.When(!date.HasValue, "Celular deve ser informado");
            ProductId = productId;
            PersonId = personId;
            Date = date.Value;
        }

    }
}
