using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoStar.Models.ViewModels
{
	public class WhiteboardCreateViewModel
	{
		public Whiteboard Whiteboard { get; set; }

		public IFormFile WhiteboardFileToSave { get; set; }
	}
}
