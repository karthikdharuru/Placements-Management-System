using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Placements_Models.Models
{
    public class StudentLogin
    {
        [Required(ErrorMessage ="Enter The StudentId")]
       
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string StudentPassword { get; set; }
    }
}