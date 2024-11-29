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
		readonly private IOrderWriteRepository _orderWriteRepository;
		readonly private ICustomerWriteRepository _customerWriteRepository;

		public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
		{
			this._productWriteRepository = productWriteRepository;
			this._productReadRepository = productReadRepository;
			this._orderWriteRepository = orderWriteRepository;
			this._customerWriteRepository = customerWriteRepository;
		}

		[HttpGet]
		public async Task Get()
		{
			var customerId = Guid.NewGuid();
			await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Deneme" });
			await _orderWriteRepository.AddAsync(new() { Description = "Deneme", Address = "Trabzon", CustomerId = customerId });
			await _orderWriteRepository.AddAsync(new() { Description = "Deneme2", Address = "İstanbul", CustomerId = customerId });
			await _orderWriteRepository.SaveAsync();
		}
	}
}
