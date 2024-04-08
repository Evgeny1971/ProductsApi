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
    public class ProductsApiRepositoryEF : IProductsApiRepository
    {
        bool isUseAdoNetOnly =true;
        private readonly ProductsDbContext _dbContext;
        private readonly ProductsDbAdoAccessor _productsDbAdoAccessor;

        public ProductsApiRepositoryEF(ProductsDbContext dbContext,
                                     ProductsDbAdoAccessor productsDbAdoAccessor)
        {
            _dbContext = dbContext;
            _productsDbAdoAccessor = productsDbAdoAccessor;
        }

        public async Task<ShopProduct> CreateShopProduct(ShopProduct ShopProduct)
        {
            try
            {
                var result = await _dbContext.ShopProducts.AddAsync(ShopProduct);
                await _dbContext.SaveChangesAsync();
                return ShopProduct;
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
                _dbContext.Remove(_dbContext.ShopProducts.Single(a => a.ID == id));
                _dbContext.SaveChanges();
                return true;
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
                var result = _dbContext.ShopProducts.
                OrderByDescending(x => x.ID).Take(10).ToList();
                return result;
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
                return await _dbContext.ShopProducts.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<ShopProduct> UpdateShopProduct(ShopProduct model)
        {
            var policy = await _dbContext.ShopProducts.FindAsync(model.ID);
            try
            {
                policy.StartOfPrice = model.StartOfPrice;
                policy.Code = model.Code;
                policy.ID = model.ID;
                policy.Description = model.Description;
                policy.Name = model.Name;
                policy.Image = model.Image;

                _dbContext.ShopProducts.Update(policy);
                await _dbContext.SaveChangesAsync();
                return policy;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}