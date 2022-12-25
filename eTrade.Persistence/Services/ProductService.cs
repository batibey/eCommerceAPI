using eTrade.Application.Abstraction.Services;
using eTrade.Application.Repositories;
using eTrade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eTrade.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IQRCodeService _qrCodeService;

        public ProductService(IProductReadRepository productReadRepository, IQRCodeService qrCodeService)
        {
            _productReadRepository = productReadRepository;
            _qrCodeService = qrCodeService;
        }

        public async Task<byte[]> QrCodeToProductAsync(string productId)
        {
            Product product = await _productReadRepository.GetByIdAsync(productId);

            if (product == null)
                throw new Exception("Product not found");

            var plainObject = new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock,
                product.CreatedDate
            };

            string plainText = JsonSerializer.Serialize(plainObject);
            return _qrCodeService.GenerateQRCode(plainText);
        }
    }
}
