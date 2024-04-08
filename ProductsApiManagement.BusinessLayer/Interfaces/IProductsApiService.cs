using ProductsApiManagement.BusinessLayer.ViewModels;
using ProductsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApiManagement.BusinessLayer.Interfaces
{
    public interface IProductsApiService
    {
        List<ShopProduct> GetAllProducts();
        Task<ShopProduct> CreateShopProduct(ShopProduct ShopProduct);
        Task<ShopProduct> GetShopProductById(long id);
        Task<bool> DeleteShopProductById(long id);
        Task<ShopProduct> UpdateShopProduct(ShopProduct model);
    }
}
