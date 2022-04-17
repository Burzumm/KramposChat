using KramposChat.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KramposChat.Dal.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
	#region IEntityTypeConfiguration<Message> members
	public void Configure(EntityTypeBuilder<Message> builder)
	{
		builder.ToTable("MESSAGES");
		// builder.Property(message => message.Id)
		// 	   .HasColumnName("ID")
		// 	   .IsRequired();
		// builder.Property(message => message.Text)
		// 	   .HasColumnName("TEXT")
		// 	   .IsRequired();
		// builder.Property(message => message.Author)
		// 	   .HasColumnName("AUTHOR")
		// 	   .IsRequired();

		builder.HasOne(message => message.Author)
			   .WithMany()
			   .HasForeignKey(user => user.Id);
	}
	#endregion
}
