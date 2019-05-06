using System;
using System.Collections.Generic;
using System.Text;
using CoStar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoStar.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		/*
		This code creates a DbSet property for each entity set. In Entity Framework terminology, an entity 
		set typically corresponds to a database table, and an entity corresponds to a row in the table.
		*/
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Principle> Principles { get; set; }
		public DbSet<HelpfulLink> Links { get; set; }
		public DbSet<IntQuestion> Questions { get; set; }
		public DbSet<Whiteboard> Whiteboards { get; set; }

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Create the applcation users (2).
			modelBuilder.Entity<ApplicationUser>()
				.Property(u => u.EnrollDate)
				.HasDefaultValueSql("GETDATE()");

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
				SecurityStamp = Guid.NewGuid().ToString("D"),
				EnrollDate = new DateTime(2008, 10, 15)
			};
			var passwordHash = new PasswordHasher<ApplicationUser>();
			user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
			modelBuilder.Entity<ApplicationUser>().HasData(user);

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
				SecurityStamp = Guid.NewGuid().ToString("D"),
				EnrollDate = new DateTime(2010, 11, 10)
			};
			var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "Admin10*");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);
			
			/******************** PRINCIPLES ********************/
			var principles = new Principle[]
			{
				// SOLID
				new Principle
				{
					PrincipleId = 1,
					PrincipleImage = "../wwwroot/Images/SOLID_Img.png",
					PrincipleName= "S.O.L.I.D.",
					PrincipleDescription="SOLID is an acronym for the first five object-oriented design(OOD) principles by Robert C. Martin. These principles, when combined together, make it easy for a programmer to develop software that are easy to maintain and extend, and are also a part of agile, an adaptive software development principle. [S]ingle Responsibility Principle, [O]pen/ Closed Principle, [L]iskov Substitution Principle, [I]ntegration Segregation Principle, [D]ependency Inversion Principle",
					UserId = null
				},

				// OPP
				new Principle
				{
					PrincipleId = 2,
					PrincipleImage = "../wwwroot/Images/OOP_Img.png",
					PrincipleName="O.O.P.",
					PrincipleDescription="Object Oriented Programming(OOP) is a language model that is organized around objects rather than actions and data rather than logic. There are four pillars of OOP: Abstraction, Polymorphism, Inheritance, and Encapsulation. You can remember this mnemonic device - A.P.I.E., because pie is awesome!",
					UserId = null
				},

				// SRP
				new Principle
				{
					PrincipleId = 3,
					PrincipleImage = "../wwwroot/Images/AGILE_Img.png",
					PrincipleName="Agile",
					PrincipleDescription="There are four values derived from the Agile Manifesto: Individuals and Interactions Over Processes and Tools, Working Software Over Comprehensive Documentation, Customer Collaboration Over Contract Negotiation, Responding to Change Over Following a Plan.",
					UserId = null
				}
			};
			modelBuilder.Entity<Principle>().HasData(principles);


			/******************** WHITEBOARD ********************/

			var whiteboards = new Whiteboard[]
			{
				// Median of Arrays
				new Whiteboard
				{
					WhiteboardId = 1,
					WhiteboardImage = "../wwwroot/Images/MedianArrays_Img.png",
					WhiteboardName="Median of Arrays",
					WhiteboardDescription="Find the median of two sorted arrays.",
					UserId= null
				},
				// Fizz Buzz
				new Whiteboard
				{
					WhiteboardId = 2,
					WhiteboardImage = "../wwwroot/Images/FizzBuzz_Img.png",
					WhiteboardName="Fizz Buzz",
					WhiteboardDescription="Write a program that prints the numbers from 1 to 100 (here I have only written it for 1 to 15). But for multiples of three print 'Fizz' instead of the number and for the multiples of five print 'Buzz'. For numbers which are multiples of both three and five print 'FizzBuzz'.",
					UserId= null
				}
			};
			modelBuilder.Entity<Whiteboard>().HasData(whiteboards);
			/******************** INTERVIEW QUESTIONS ********************/
			var intQuestions = new IntQuestion[]
			{
				// Question 1
				new IntQuestion{
					IntQuestionId = 1,
					IntQuestionName="What are the two types of pop-ups?",
					IntQuestionDescription="Alert and Prompt.",
					UserId = null
				},
				// Question 2
				new IntQuestion{
					IntQuestionId = 2,
					IntQuestionName="What is the disadvantage of using : 'innerHTML'?",
					IntQuestionDescription="Content can be replaced anywhere.",
					UserId = null
				},
				// Question 3
				new IntQuestion{
					IntQuestionId = 3,
					IntQuestionName="What is the difference between var and let?",
					IntQuestionDescription="var is function-scoped and let is block-scoped.",
					UserId = null
				},
				// Question 4
				new IntQuestion{
					IntQuestionId = 4,
					IntQuestionName="What is the difference between '==' and '==='?",
					IntQuestionDescription="The first option == checks value equality, whereas === returns false, and checks both type and value equality.",
					UserId = null
				}
			};
			modelBuilder.Entity<IntQuestion>().HasData(intQuestions);
			/******************** HELPFUL LINKS ********************/
			var helpfulLinks = new HelpfulLink[]
			{
				// Link 1
				new HelpfulLink{
					LinkId = 1,
					LinkUrl="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference",
					LinkDescription="JavaScript language Documentation",
					UserId = null
				},
				// Link 2
				new HelpfulLink{
					LinkId = 2,
					LinkUrl="https://docs.microsoft.com/en-us/dotnet/csharp/",
					LinkDescription="C# language Documentation",
					UserId = null
				},
				// Link 3
				new HelpfulLink{
					LinkId = 3,
					LinkUrl="https://reactjs.org/docs/getting-started.html",
					LinkDescription="React - Getting Started",
					UserId = null
				}
			};
			modelBuilder.Entity<HelpfulLink>().HasData(helpfulLinks);
		}
	}
}
