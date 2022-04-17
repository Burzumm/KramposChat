using KramposChat.Dal;
using KramposChat.Service.Extensions;
using KramposChat.Service.SignalRHub;

namespace KramposChat.Service;

public class Startup
{
	#region .ctor
	public Startup(IConfiguration configuration) => Configuration = configuration;
	#endregion

	#region Properties
	public IConfiguration Configuration
	{
		get;
	}
	#endregion

	#region Public
	public void Configure(IApplicationBuilder app, IHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Error");
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseDefaultFiles();
		app.UseStaticFiles();
		app.UseRouting();
		app.UseWebSockets();
		app.UseCors();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
			endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
			endpoints.MapFallbackToFile("index.html");
			endpoints.MapHub<ChatHub>("/chathub");
		});
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDataBase(GetPostgresConnectionString());
		services.AddDbContext<KramposChatDbContext>();
		services.AddControllers();
		services.AddSignalR();
		services.AddCors(options =>
		{
			options.AddDefaultPolicy(builder =>
			{
				builder.AllowAnyMethod()
					   .AllowAnyHeader()
					   .SetIsOriginAllowed(_ => true)
					   .AllowCredentials();
			});
		});
	}
	#endregion

	#region Private
	private string GetPostgresConnectionString() => Configuration.GetConnectionString("PostgresConnectionString");
	#endregion
}
