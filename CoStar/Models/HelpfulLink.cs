using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoStar.Models
{
	public class HelpfulLink
	{
		[Key]
		public int LinkId { get; set; }

		public string LinkImage { get; set; }

		[Required]
		[Display(Name = "Link Name")]
		public string LinkName { get; set; }

		[Required]
		[Display(Name = "Link Description")]
		public string LinkDescription { get; set; }

		public ApplicationUser User { get; set; }
	}
}
