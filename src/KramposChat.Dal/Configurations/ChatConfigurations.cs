using KramposChat.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KramposChat.Dal.Configurations;

public class ChatConfigurations : IEntityTypeConfiguration<Chat>
{
	#region IEntityTypeConfiguration<Chat> members
	public void Configure(EntityTypeBuilder<Chat> builder)
	{
		builder.ToTable("CHATS");
		// builder.Property(chat => chat.Id)
		// 	   .HasColumnName("ID");
		// builder.Property(chat => chat.Name)
		// 	   .HasColumnName("NAME")
		// 	   .IsRequired();
		// builder.Property(chat => chat.Messages)
		// 	   .HasColumnName("MESSAGES");
		// builder.Property(chat => chat.Users)
		// 	   .HasColumnName("USERS");

		builder.HasMany(chat => chat.Users)
			   .WithMany(user => user.Chats);

		builder.HasMany(chat => chat.Messages)
			   .WithOne()
			   .HasForeignKey(message => message.Id);
	}
	#endregion
}
