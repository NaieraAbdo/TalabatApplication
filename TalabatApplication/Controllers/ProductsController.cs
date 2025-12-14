using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.repositories;
using Talabat.Core.Specifications;
using TalabatApplication.DTOs;

namespace TalabatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> productrepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> Productrepo,IMapper mapper)
        {
            productrepo = Productrepo;
            this.mapper = mapper;
        }

        //GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //var Products = await productrepo.GetAllAsync();
            var spec = new ProductSpecWithBrandAndTypeSpec();
            var Products = await productrepo.GetAllAsyncWithSpec(spec);
            var mappedproducts = mapper.Map<IEnumerable<Product>,IEnumerable< ProductDTO>>(Products);
            return Ok(mappedproducts);


        }
        //Get By id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //var product = await productrepo.GetByIdAsync(id);
            var spec = new ProductSpecWithBrandAndTypeSpec(id);
            var product = await productrepo.GetByIdAsyncWithSpec(spec);
            var mappedProduct = mapper.Map<Product, ProductDTO>(product);
            return Ok(mappedProduct);
        }

    }
}
