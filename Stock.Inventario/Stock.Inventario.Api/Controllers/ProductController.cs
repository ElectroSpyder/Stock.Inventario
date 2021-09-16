namespace Stock.Inventario.Api.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Stock.Inventario.Api.DTO;
    using Stock.Inventario.Api.Helper;
    using Stock.Inventario.Api.Services;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        [Route("/auth/register")]
        public async Task<ActionResult< Response>> Get()
        {
            try
            {
                var result = await _productservice.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ProductDto dto)
        {
            try
            {
                var result = await _productservice.Add(dto);

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
