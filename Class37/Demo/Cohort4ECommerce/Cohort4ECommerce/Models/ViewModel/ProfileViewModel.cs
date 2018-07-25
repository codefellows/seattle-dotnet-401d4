using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort4ECommerce.Models.ViewModel
{
    public class ProfileViewModel
    {
		[Display(Name="First Name")]
		public string FirstName { get; set; }
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		[Display(Name = "Email")]
		public string Email { get; set; }

	}
}
