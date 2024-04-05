using ProductsApiManagement.BusinessLayer.Interfaces;
using ProductsApiManagement.BusinessLayer.ViewModels;
using ProductsApiManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsApiManagement.Controllers
{
    [ApiController]
    public class ShopProductController : ControllerBase
    {
        private readonly IProductsApiService _ProductsApiService;
        public ShopProductController(IProductsApiService ProductsApiService)
        {
            _ProductsApiService = ProductsApiService;
        }

        [HttpPost]
        [Route("create-policy")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateShopProduct([FromBody] ShopProduct model)
        {
            var policyExists = await _ProductsApiService.GetShopProductById(model.ID);
            if (policyExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy already exists!" });
            var result = await _ProductsApiService.CreateShopProduct(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Insurance Policy created successfully!" });

        }


        [HttpPut]
        [Route("update-policy")]
        public async Task<IActionResult> UpdateShopProduct([FromBody] ShopProductViewModel model)
        {
            var policy = await _ProductsApiService.UpdateShopProduct(model);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {model.ID} cannot be found" });
            }
            else
            {
                var result = await _ProductsApiService.UpdateShopProduct(model);
                return Ok(new Response { Status = "Success", Message = "Insurance Policy updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-policy")]
        public async Task<IActionResult> DeleteShopProduct(long id)
        {
            var policy = await _ProductsApiService.GetShopProductById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _ProductsApiService.DeleteShopProductById(id);
                return Ok(new Response { Status = "Success", Message = "Insurance policy deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-policy-by-id")]
        public async Task<IActionResult> GetShopProductById(long id)
        {
            var policy = await _ProductsApiService.GetShopProductById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Insurance Policy With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(policy);
            }
        }

        [HttpGet]
        [Route("get-all-policies")]
        public async Task<IEnumerable<ShopProduct>> GetAllPolicies()
        {
            return _ProductsApiService.GetAllInsurancePolicies();
        }

        
    }
}