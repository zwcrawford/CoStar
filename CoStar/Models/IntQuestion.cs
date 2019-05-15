using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoStar.Models
{
	public class IntQuestion
	{
		[Key]
		public int IntQuestionId { get; set; }

		[Required]
		[Display(Name = "Question")]
		public string IntQuestionName { get; set; }

		[Required]
		[Display(Name = "Answer")]
		public string IntQuestionDescription { get; set; }

		public string UserId { get; set; }

		public ApplicationUser User { get; set; }
	}
}
