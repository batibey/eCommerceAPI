using eTrade.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün Adını Boş Geçmeyin !")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen Ürün Adını 2-150 karakter arasında girin !");

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Stock Bilgisini Boş Geçmeyin !")
                .Must(s => s >= 0)
                .WithMessage("Stock Bilgisi Negatif Olamaz !");

            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Fiyat Bilgisini Boş Geçmeyin !")
                .Must(s => s >= 0)
                .WithMessage("Fiyat Bilgisi Negatif Olamaz !");
        }
    }
}
