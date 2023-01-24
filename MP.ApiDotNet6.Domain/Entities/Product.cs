using MP.ApiDotNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }
        public Product(string coderp, decimal price, string name)
        {
            Validation(coderp, price, name);
            Purchases = new List<Purchase>();
        }
        public Product(int id,string coderp, decimal price, string name)
        {
            DomainValidationException.When(id < 0, "Id do produto deve ser informado");
            Id= id;
            Validation(coderp, price, name);
            Purchases = new List<Purchase>();
        }

        public void Validation(string coderp, decimal price, string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(coderp), "CodErp deve ser Informado");
            DomainValidationException.When(string.IsNullOrEmpty(Name), "Nome deve ser Informado");
            DomainValidationException.When(price<0, "Preço deve ser Informado");
            Name = name;
            Price = price;
            CodErp = coderp;

        }
    }
}
