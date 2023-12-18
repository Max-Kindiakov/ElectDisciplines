﻿using ElectDiscipline_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectDiscipline_Web.Models.VM
{
	public class DisciplineNumberDeleteVM
	{
		public DisciplineNumberDeleteVM()
		{
			DisciplineNumber = new DisciplineNumberDTO();
		}
		public DisciplineNumberDTO DisciplineNumber { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> DisciplineList { get; set; }
	}
}
