using FluentValidation;
using Nw.Entitiess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nw.Busines.Concrete.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismini girmeniz gerekli");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Ürün ismini girmeniz gerekli");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Ürün ismini girmeniz gerekli");
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Ürün ismini girmeniz gerekli");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Ürün ismini girmeniz gerekli");
        }
    }
}
