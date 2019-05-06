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
		[Display(Name = "Interview Question Name")]
		public string IntQuestionName { get; set; }

		[Required]
		[Display(Name = "Interview Question Description")]
		public string IntQuestionDescription { get; set; }

		public ApplicationUser UserId { get; set; }
	}
}
