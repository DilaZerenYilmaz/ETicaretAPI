using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);

			services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
			services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
			services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
			services.AddSingleton<IProductReadRepository, ProductReadRepository>();
			services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
		}
	}
}
