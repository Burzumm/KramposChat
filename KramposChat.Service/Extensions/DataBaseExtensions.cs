using Microsoft.EntityFrameworkCore;

namespace KramposChat.Service.Extensions;

public static class DataBaseExtensions
{
	public static void AddDataBase(this IServiceCollection serviceCollection, string connectionString)
	{
		if (serviceCollection == null)
		{
			throw new ArgumentNullException(nameof(serviceCollection));
		}

		if (string.IsNullOrWhiteSpace(connectionString))
		{
			throw new ArgumentException(nameof(connectionString));
		}
		

		void AddDbContext<TDbContext>() where TDbContext : DbContext
		{
			serviceCollection.AddDbContext<TDbContext>(SetupContext);
		}

		void SetupContext(DbContextOptionsBuilder builder)
		{
			builder.UseNpgsql(connectionString);

			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			if (environment != "PRODUCTION")
			{
				builder.EnableSensitiveDataLogging();
			}
			
		}
	}

}
