using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Placements_Model.Models
{
    public class Student
    {
        [Required]
        [Range(0, 2147483647,ErrorMessage ="Enter a valid number")]
      
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(2)]
        [MaxLength(45)]
        [DataType(DataType.Password)]
        public string StudentPassword { get; set; }

        [Required]
        [MinLength(2)][StringLength(45)]
        public string StudentName { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DoB { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Branch { get; set; }

        [Required]
        [Range(0.0,10.0)]
        public float Cgpa { get; set; }

        [Required]
        [Range(0.0,100.0)]
        public float Percentage { get; set; }

        [Range(0,60)]
        public int Backlogs { get; set; }

        public bool IsFessPaid { get; set; }

        public bool IsPlaced { get; set; }

        [Required]
        [Range(1, 2147483647)]
        public int Package { get; set; }

        [Required]
        [MinLength(2)]
        public string Company { get; set; }
       
        


    }
}