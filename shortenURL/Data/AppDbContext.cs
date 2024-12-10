using Microsoft.EntityFrameworkCore;
using shortenURL.Models;

namespace shortenURL.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Url> Urls { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Configure the relationship between Url and IdentityUser
			builder.Entity<Url>()
				.HasOne(u => u.User)
				.WithMany()
				.HasForeignKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict); // Adjust behavior as needed
		}
	}
}


