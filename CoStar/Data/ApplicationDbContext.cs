using System;
using System.Collections.Generic;
using System.Text;
using CoStar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CoStar.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		/*
		This code creates a DbSet property for each entity set. In Entity Framework terminology, an entity set typically
		corresponds to a database table, and an entity corresponds to a row in the table.
		*/
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Principle> Principles { get; set; }
		public DbSet<HelpfulLink> Links { get; set; }
		public DbSet<IntQuestion> Questions { get; set; }
		public DbSet<Whiteboard> Whiteboards { get; set; }

		/*
		Property names for collections are typically plural (Principles rather than Principle), but developers disagree about
		whether table names should be pluralized or not. For this project, I have overridden the default behavior by
		specifying singular table names in the DbContext.
		*/
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Principle>().ToTable("Principle");
			modelBuilder.Entity<HelpfulLink>().ToTable("Link");
			modelBuilder.Entity<IntQuestion>().ToTable("IntQuestion");
			modelBuilder.Entity<Whiteboard>().ToTable("Whiteboard");
			modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");


			base.OnModelCreating(modelBuilder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			modelBuilder.Entity<ApplicationUser>().Map(delegate(EntityMappingConfiguration<ApplicationUser> userConfig)
			{
				m.Properties(p => new {p.UserId});
				m.ToTable("Principle");
			})
			

			// Restrict deletion of related order when OrderProducts entry is removed
			modelBuilder.Entity<HelpfulLink>()
				.HasMany(o => o.OrderProducts)
				.WithOne(l => l.Order)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<IntQuestion>()
				.Property(b => b.DateCreated)
				.HasDefaultValueSql("GETDATE()");

			// Restrict deletion of related product when OrderProducts entry is removed
			modelBuilder.Entity<Whiteboard>()
				.HasMany(o => o.OrderProducts)
				.WithOne(l => l.Product)
				.OnDelete(DeleteBehavior.Restrict);
		}
		ApplicationUser user = new ApplicationUser
		{
			FirstName = "Admin",
			LastName = "Admin",
			UserName = "admin@admin.com",
			NormalizedUserName = "ADMIN@ADMIN.COM",
			Email = "admin@admin.com",
			NormalizedEmail = "admin@ADMIN.COM",
			EmailConfirmed = true,
			LockoutEnabled = false,
			SecurityStamp = Guid.NewGuid().ToString("D")
		};

		ApplicationUser user2 = new ApplicationUser
		{
			FirstName = "Guest",
			LastName = "Guest",
			UserName = "guest@admin.com",
			NormalizedUserName = "GUEST@ADMIN.COM",
			Email = "guest@admin.com",
			NormalizedEmail = "guest@ADMIN.COM",
			EmailConfirmed = true,
			LockoutEnabled = false,
			SecurityStamp = Guid.NewGuid().ToString("D")
		};
	}
}
