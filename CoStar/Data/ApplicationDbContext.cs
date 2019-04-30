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
		public DbSet<Principle> Principles { get; set; }
		public DbSet<HelpfulLink> Links { get; set; }
		public DbSet<IntQuestion> Questions { get; set; }
		public DbSet<Whiteboard> Whiteboards { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
	}
}
}
