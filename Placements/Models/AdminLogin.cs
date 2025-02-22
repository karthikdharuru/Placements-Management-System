using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Placements.Models
{
    public class AdminLogin
    {
        [Required(ErrorMessage = "Enter The AdminId")]
        
        public string AdminId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}