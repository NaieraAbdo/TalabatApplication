using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.repositories;
using Talabat.Core.Specifications;

namespace TalabatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productrepo;

        public ProductsController(IGenericRepository<Product> Productrepo)
        {
            productrepo = Productrepo;
        }

        //GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //var Products = await productrepo.GetAllAsync();
            var spec = new ProductSpecWithBrandAndTypeSpec();
            var Products = await productrepo.GetAllAsyncWithSpec(spec);
            return Ok(Products);


        }
        //Get By id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //var product = await productrepo.GetByIdAsync(id);
            var spec = new ProductSpecWithBrandAndTypeSpec(id);
            var product = await productrepo.GetByIdAsyncWithSpec(spec);
            return Ok(product);
        }

    }
}
