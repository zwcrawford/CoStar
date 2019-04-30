using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoStar.Models
{
	public class Principle
	{
		[Key]
		public int PrincipleId { get; set; }

		public string PrincipleImage { get; set; }

		[Required]
		[Display(Name = "Principle Name")]
		public string PrincipleName { get; set; }

		[Required]
		[Display(Name = "Principle Description")]
		public string PrincipleDescription { get; set; }

		public ApplicationUser User { get; set; }
	}
}
