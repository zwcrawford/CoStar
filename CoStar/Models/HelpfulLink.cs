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
		public int HelpfulLinkId { get; set; }

		[Required]
		[Display(Name = "Link URL")]
		public string LinkUrl { get; set; }

		[Required]
		[Display(Name = "Link Description")]
		public string LinkDescription { get; set; }

		public string UserId { get; set; }

		public ApplicationUser User { get; set; }
	}
}
