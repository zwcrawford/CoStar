using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoStar.Models
{
	public class Image
	{
		[Key]
		public int ImageId { get; set; }

		[Required]
		[Display(Name = "Image Location")]
		public string ImageLocation { get; set; }

		public bool isImageDisplayed { get; set; }

		public ApplicationUser UserId { get; set; }
	}
}
