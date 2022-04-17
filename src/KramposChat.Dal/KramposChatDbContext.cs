using System.Reflection;
using KramposChat.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace KramposChat.Dal;

public class KramposChatDbContext : DbContext
{
	#region .ctor
	public KramposChatDbContext(DbContextOptions<KramposChatDbContext> options)
		: base(options)
	{
	}
	#endregion

	#region Properties
	public DbSet<Chat> Chats
	{
		get;
		set;
	} = null!;

	public DbSet<Message> Messages
	{
		get;
		set;
	} = null!;

	public DbSet<User> Users
	{
		get;
		set;
	} = null!;
	#endregion

	#region Overrided
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
	#endregion
}
