using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoStar.Models
{
	public class IntQuestion
	{
		public string IntQuestionImage { get; set; }

		[Required]
		[Display(Name = "Interview Question Name")]
		public string IntQuestionName { get; set; }

		[Required]
		[Display(Name = "Interview Question Description")]
		public string IntQuestionDescription { get; set; }

		public ApplicationUser User { get; set; }
	}
}
