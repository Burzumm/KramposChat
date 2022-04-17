using KramposChat.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KramposChat.Dal.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	#region IEntityTypeConfiguration<User> members
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("USERS");
		// builder.Property(user => user.Id)
		// 	   .HasColumnName("ID");
		// builder.Property(user => user.Name)
		// 	   .HasColumnName("NAME");
		// builder.Property(user => user.Chats)
		// 	   .HasColumnName("USER");
	}
	#endregion
}
