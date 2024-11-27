using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		readonly private IProductWriteRepository _productWriteRepository;
		readonly private IProductReadRepository _productReadRepository;

		public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
		{
			this._productWriteRepository = productWriteRepository;
			this._productReadRepository = productReadRepository;
		}

		[HttpGet]
		public async Task Get()
		{
			//await _productWriteRepository.AddRangeAsync(new()
			//{
			//	new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10},
			//	new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20},
			//	new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30},
			//});
			//await _productWriteRepository.SaveAsync();

			Product p = await _productReadRepository.GetByIdAsync("32fa4df5-1877-4c11-973c-e93d821f807e", false);
			p.Name = "Mehmet";
			await _productWriteRepository.SaveAsync();
		}
	}
}
