using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Categories.Queries.GetCategory;
using ShoppingList.Application.Commands.CreateCategory;
using ShoppingList.Application.Product.Commands.CreateProduct;
using ShoppingList.Application.Product.Queries.GetProducts;
using ShoppingList.Domain.Entities;

namespace ShoppingList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController
    {

        [HttpPost("product")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            Product result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("category")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            Category result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("product")]
        public async Task<IActionResult> GetAllProduct()
        {
            List<ProductDto> productList = await Mediator.Send(new GetProductsQuery());
            return productList.Any() ? Ok(productList) : NotFound();
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetAllCategory()
        {
            List<CategoryDto> categoryList = await Mediator.Send(new GetCategoryQuery());
            return categoryList.Any() ? Ok(categoryList) : NotFound();
        }
        [HttpGet("category/{name}")]
        public async Task<CategoryDto> GetByCategoryName(string name)
        {
            List<CategoryDto> categories = await Mediator.Send(new GetCategoryQuery());
            var result = categories.SingleOrDefault(x => x.Name.Equals(name));
            if (result == null)
                throw new Exception("Kategori Bulunamadı");
            return result;
        }
        [HttpGet("product/{name}")]
        public async Task<ProductDto> GetByProductName(string name)
        {
            List<ProductDto> products = await Mediator.Send(new GetProductsQuery());
            var result = products.SingleOrDefault(x => x.Name.Equals(name));
            if (result == null)
                throw new Exception("Ürün bulunamadı");
            return result;
        }
        [HttpGet("category/{date}")]
        public async Task<CategoryDto> GetByCategoryCreatedDate(DateTime date)
        {
            List<CategoryDto> categories = await Mediator.Send(new GetCategoryQuery());
            var result = categories.SingleOrDefault(x => x.CreatedDate.Equals(date));
            if (result == null)
                throw new Exception("Bu tarihte oluşturulan bir category bulunamadı.");
            return result;
        }
    }
}
