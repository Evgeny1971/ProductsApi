using ProductsApiManagement.BusinessLayer.ViewModels;
using ProductsApiManagement.DataLayer;
using ProductsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApiManagement.BusinessLayer.Services.Repository
{
    public class ProductsApiRepository : IProductsApiRepository
    {
        bool isUseAdoNetOnly =true;
        private readonly ProductsDbContext _dbContext;
        private readonly ProductsDbAdoAccessor _productsDbAdoAccessor;

        public ProductsApiRepository(ProductsDbContext dbContext,
                                     ProductsDbAdoAccessor productsDbAdoAccessor)
        {
            _dbContext = dbContext;
            _productsDbAdoAccessor = productsDbAdoAccessor;
        }

        public async Task<ShopProduct> CreateShopProduct(ShopProduct shopProduct)
        {
            try
            {
                await _productsDbAdoAccessor.CreateShopProduct(shopProduct);
                return shopProduct;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteShopProductById(long id)
        {
            try
            {
                return await _productsDbAdoAccessor.DeleteShopProductById(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<ShopProduct> GetAllProducts()
        {
            try
            {
                return _productsDbAdoAccessor.GetAllProducts().Result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ShopProduct> GetShopProductById(long id)
        {
            try
            {
                return await _productsDbAdoAccessor.GetShopProductById(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<ShopProduct> UpdateShopProduct(ShopProduct model)
        { 
            try
            {
                return await _productsDbAdoAccessor.UpdateShopProduct(model);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}