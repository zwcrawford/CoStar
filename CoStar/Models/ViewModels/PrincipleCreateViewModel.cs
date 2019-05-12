using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoStar.Models.ViewModels
{
	public class PrincipleCreateViewModel
	{
		public Principle Principle { get; set; }

		public IFormFile PrincipleFileToSave { get; set; }
	}
}
