using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Placements.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string StudentPassword { get; set; }
        [Required]
        public string StudentName { get; set; }
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$",ErrorMessage ="enter valid DOB")]
        public DateTime DoB { get; set; }
        [EmailAddress][Required]
        public string Email { get; set; }
        [Phone]
        public int Mobile { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public float Cgpa { get; set; }
        [Required]
        public float Percentage { get; set; }
        public int Backlogs { get; set; }
        public bool IsFessPaid { get; set; }
        public bool IsPlaced { get; set; }
        [Required]
        public int Package { get; set; }
        [Required]
        public string Company { get; set; }
       
        


    }
}