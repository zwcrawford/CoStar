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

			/******************** PRINCIPLE ********************/
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
				},
			};
			foreach (Principle p in principles)
			{
				context.Principles.Add(p);
			}
			context.SaveChanges();

			/******************** WHITEBOARD ********************/
			var whiteboards = new Whiteboard[]
			{
				// SRP
				new Whiteboard
				{
				WhiteboardId = 1,
				WhiteboardName="Median of Arrays",
				WhiteboardDescription="Find the median of two sorted arrays.",
				UserId= null
				
				},
			};
			foreach (Whiteboard w in whiteboards)
			{
				context.Whiteboards.Add(w);
			}
			context.SaveChanges();

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
				},
			};
			foreach (IntQuestion i in intQuestions)
			{
				context.Questions.Add(i);
			}
			context.SaveChanges();

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
			};
			foreach (IntQuestion i in intQuestions)
			{
				context.Questions.Add(i);
			}
			context.SaveChanges();
		}
	}
}
