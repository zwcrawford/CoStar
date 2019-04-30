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
	}
}
