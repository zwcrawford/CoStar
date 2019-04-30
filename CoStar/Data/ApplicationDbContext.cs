using System;
using System.Collections.Generic;
using System.Text;
using CoStar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoStar.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		/*
		This code creates a DbSet property for each entity set. In Entity Framework terminology, an entity set typically
		corresponds to a database table, and an entity corresponds to a row in the table.
		*/
		public DbSet<Principle> Principles { get; set; }
		public DbSet<HelpfulLink> Links { get; set; }
		public DbSet<IntQuestion> Questions { get; set; }
		public DbSet<Whiteboard> Whiteboards { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
		}
	}
}
