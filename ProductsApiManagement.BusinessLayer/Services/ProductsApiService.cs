using ProductsApiManagement.BusinessLayer.Interfaces;
using ProductsApiManagement.BusinessLayer.Services.Repository;
using ProductsApiManagement.BusinessLayer.ViewModels;
using ProductsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApiManagement.BusinessLayer.Services
{
    public class ProductsApiService : IProductsApiService
    {
        private readonly IProductsApiRepository _ProductsApiRepository;

        public ProductsApiService(IProductsApiRepository ProductsApiRepository)
        {
            _ProductsApiRepository = ProductsApiRepository;
        }

        public async Task<ShopProduct> CreateShopProduct(ShopProduct ShopProduct)
        {
            return await _ProductsApiRepository.CreateShopProduct(ShopProduct);
        }

        public async Task<bool> DeleteShopProductById(long id)
        {
            return await _ProductsApiRepository.DeleteShopProductById(id);
        }

        public List<ShopProduct> GetAllProducts()
        {
            return _ProductsApiRepository.GetAllProducts();
        }

        public async Task<ShopProduct> GetShopProductById(long id)
        {
            return await _ProductsApiRepository.GetShopProductById(id);
        }

        public async Task<ShopProduct> UpdateShopProduct(ShopProduct model)
        {
            return await _ProductsApiRepository.UpdateShopProduct(model);
        }
    }
}