using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoStar.Models
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser
	{
		
		public ApplicationUser()
		{

		}
		public byte[] ApplicationUserImage { get; set; }

		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public  DateTime EnrollDate { get; set; }

		public virtual ICollection<Principle> Principles { get; set; }
		public virtual ICollection<HelpfulLink> HelpfulLinks { get; set; }
		public virtual ICollection<IntQuestion> IntQuestions { get; set; }
		public virtual ICollection<Whiteboard> Whiteboards { get; set; }
	}
}

