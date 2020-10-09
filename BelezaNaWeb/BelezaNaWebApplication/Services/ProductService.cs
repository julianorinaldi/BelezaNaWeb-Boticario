using BelezaNaWebDomain;
using BelezaNaWebDomain.Repositories;
using BelezaNaWebDomain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product?.SKU))
                throw new Exception("SKU não encontrado!");

            var productGet = _productRepository.FindByIdAsync(product.SKU);
            if (!string.IsNullOrWhiteSpace(productGet.Result?.SKU))
                throw new Exception($"Produto já existente, não é possível adicionar SKU {product?.SKU} duplicado!");

            _productRepository.AddAync(product);
        }

        public void DeleteProduct(string sku)
        {
            var productGet = _productRepository.FindByIdAsync(sku);
            if (string.IsNullOrWhiteSpace(productGet.Result?.SKU))
                throw new Exception($"Produto não existente, não é possível deletar produto com SKU {sku}!");

            _productRepository.Remove(productGet.Result);
        }

        public async Task<Product> GetProductAsync(string sku)
        {
            return await _productRepository.FindByIdAsync(sku);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public void UpdateProduct(Product product)
        {
            if (!string.IsNullOrWhiteSpace(product?.SKU))
                throw new Exception("Produto incompleto, sem SKU!");

            var productGet = _productRepository.FindByIdAsync(product.SKU);
            if (!string.IsNullOrWhiteSpace(productGet.Result?.SKU))
            {
                product.Name = productGet.Result.Name;
                _productRepository.Update(product);
            }
            else
                throw new Exception($"Produto não encontrado com SKU {product?.SKU}!");
        }
    }
}