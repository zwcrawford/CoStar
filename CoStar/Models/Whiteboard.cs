using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoStar.Models
{
	public class Whiteboard
	{
		[Key]
		public int WhiteboardId { get; set; }

		public string WhiteboardImage { get; set; }

		[Required]
		[Display(Name = "Whiteboard Name")]
		public string WhiteboardName { get; set; }

		[Required]
		[Display(Name = "Whiteboard Description")]
		public string WhiteboardDescription { get; set; }

		public string UserId { get; set; }

		public ApplicationUser User { get; set; }
	}
}
