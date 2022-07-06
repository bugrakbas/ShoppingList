using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using ShoppingList.Application.Categories.Queries.GetCategory;
using ShoppingList.Application.Commands.CreateCategory;
using ShoppingList.Application.Common.Interfaces.Repositories;
using ShoppingList.Application.Product.Commands.CreateProduct;
using ShoppingList.Application.Product.Queries.GetProducts;
using ShoppingList.Application.Users.Commands.CreateUser;
using ShoppingList.Application.Users.Queries.GetUser;
using ShoppingList.Domain.DTOs;
using ShoppingList.Domain.Entities;
using System.Text;
using System.Text.Json;

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
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDtoRepository _categoryDtoRepository;
        public ShoppingListController(IMemoryCache memoryCache, IDistributedCache distributedCache, ICategoryRepository categoryRepository, ICategoryDtoRepository categoryDtoRepository)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
            _categoryRepository = categoryRepository;
            _categoryDtoRepository = categoryDtoRepository;
        }

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
        [HttpPost("user")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            User result = await Mediator.Send(command);
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
            IActionResult retVal = null;
            List<CategoryDto> categories = null;
            byte[] cached = _distributedCache.Get("category");
            if (cached == null)
            {
                categories = await Mediator.Send(new GetCategoryQuery());
            }
            else
            {
                string jsonData = Encoding.UTF8.GetString(cached);
                categories = JsonSerializer.Deserialize<List<CategoryDto>>(jsonData);
            }
            if (categories == null)
            {
                retVal = BadRequest();
            }
            else
            {
                if (cached == null)
                {
                    string jsonCategories = JsonSerializer.Serialize(categories);
                    _distributedCache.Set("category", Encoding.UTF8.GetBytes(jsonCategories), new DistributedCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddMinutes(2) });
                }
                retVal = Ok(categories);
            }
            return retVal;
        }
        [HttpGet("GelAllUsers")]
        public async Task<IActionResult> GetAllUser()
        {
            IActionResult retVal = null;
            List<UserDto> users = null;
            byte[] cached = _distributedCache.Get("GetAllUsers");
            if (cached == null)
            {

                users = await Mediator.Send(new GetUserQuery());
            }
            else
            {
                string jsonData = Encoding.UTF8.GetString(cached);
                users = JsonSerializer.Deserialize<List<UserDto>>(jsonData);
            }
            if (users == null)
            {
                retVal = BadRequest();
            }
            else
            {
                if (cached == null)
                {
                    string jsonUsers = JsonSerializer.Serialize(users);
                    _distributedCache.Set("GetAllUsers", Encoding.UTF8.GetBytes(jsonUsers), new DistributedCacheEntryOptions() { AbsoluteExpiration = DateTime.Now.AddMinutes(2) });
                }
                retVal = Ok(users);
            }
            return retVal;
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
        [HttpGet("user/{name}")]
        public async Task<UserDto> GetByUserName(string name)
        {
            List<UserDto> users = await Mediator.Send(new GetUserQuery());
            var result = users.SingleOrDefault(x => x.FirstName.Equals(name));
            if (result == null)
                throw new Exception("Kişi bulunamadı");
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
        [HttpPut("category")]
        public async Task<IActionResult> Update([FromBody] CategoryDtos categoryDto)
        {
            
            CategoryDtos result = await _categoryDtoRepository.Update(categoryDto);
            IActionResult retVal = null;
            if (result != null)
            {
                _distributedCache.RemoveAsync("category");
                retVal = Ok(result);
            }
            else
            {
                retVal = BadRequest(result);
            }
            return retVal;
        }
        [HttpDelete("category")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            Category category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);
            return Ok();
        }
    }
}
