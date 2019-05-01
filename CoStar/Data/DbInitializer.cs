using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoStar.Models;

namespace CoStar.Data
{
	public class DbInitializer
	{
		public static void Initialize(ApplicationDbContext context)
		{
			context.Database.EnsureCreated();

			// Look for any principles.
			if (context.Principles.Any())
			{
				return;   // DB has been seeded
			}

			var principles = new Principle[]
			{

			// SOLID
			new Principle{
			PrincipleName= "S.O.L.I.D.",
			PrincipleDescription="SOLID is an acronym for the first five object-oriented design(OOD) principles by Robert C. Martin. These principles, when combined together, make it easy for a programmer to develop software that are easy to maintain and extend, and are also a part of agile, an adaptive software development principle. [S]ingle Responsibility Principle, [O]pen/ Closed Principle, [L]iskov Substitution Principle, [I]ntegration Segregation Principle, [D]ependency Inversion Principle",
			UserId= null
			},

			// OPP
			new Principle{
			PrincipleName="O.O.P.",
			PrincipleDescription="Object Oriented Programming(OOP) is a language model that is organized around objects rather than actions and data rather than logic. There are four pillars of OOP: Abstraction, Polymorphism, Inheritance, and Encapsulation. You can remember this mnemonic device - A.P.I.E., because pie is awesome!",
			UserId= null},

			// SRP
			new Principle{
			PrincipleName="Agile",
			PrincipleDescription="There are four values derived from the Agile Manifesto: Individuals and Interactions Over Processes and Tools, Working Software Over Comprehensive Documentation, Customer Collaboration Over Contract Negotiation, Responding to Change Over Following a Plan. There are also twelve basic principles that one should adhere to if using the Agile methodology: [1] Customer satisfaction through early and continuous software delivery. [2] Accommodate changing requirements throughout the development process, [3] Frequent delivery of working software, [4] Collaboration between the business stakeholders and developers throughout the project, [5] Support, trust, and motivate the people involved, [6] Enable face-to-face interactions, [7] Working software is the primary measure of progress, [8] Agile processes to support a consistent development pace, [9] Attention to technical detail and design enhances agility, [10] Simplicity, [11] Self-organizing teams encourage great architectures, requirements, and designs, and [12] Regular reflections on how to become more effective.",
			UserId = null},
			};
			foreach (Principle p in principles)
			{
				context.Principles.Add(p);
			}
			context.SaveChanges();

			var whiteboards = new Whiteboard[]
			{
			// SRP
			new Whiteboard{

			WhiteboardName="Median of Arrays",
			WhiteboardDescription="Find the median of two sorted arrays.",
			UserId= null},
			};
			foreach (Whiteboard c in whiteboards)
			{
				context.Whiteboards.Add(c);
			}
			context.SaveChanges();

			var enrollments = new Enrollment[]
			{
			new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
			new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
			new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
			new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
			new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
			new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
			new Enrollment{StudentID=3,CourseID=1050},
			new Enrollment{StudentID=4,CourseID=1050},
			new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
			new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
			new Enrollment{StudentID=6,CourseID=1045},
			new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
			};
			foreach (Enrollment e in enrollments)
			{
				context.Enrollments.Add(e);
			}
			context.SaveChanges();
		}
	}
}
