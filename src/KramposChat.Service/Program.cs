namespace KramposChat.Service;

public class Program
{
	#region Public
	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			});

	public static void Main(string[] args)
	{
		CreateHostBuilder(args)
			.Build()
			.Run();
	}
	#endregion
}
