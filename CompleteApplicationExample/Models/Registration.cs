using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompleteApplicationExample.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80)]
        [MinLength(3,ErrorMessage ="Min length 3")]
        [Required(ErrorMessage = "Fill the Name")]
        [RegularExpression(@"[a-zA-Z\s]{3,}", ErrorMessage = "Min length 3, don't fill Digits")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill the Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "10 digit Mobile Number starts with 6,7,8,9")]
        public string Mobile { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Fill the Email ID")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email ID")]
        public string Email { get; set; }
        [StringLength(16)]
        [Required(ErrorMessage = "Fill the Password")]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{6,16}",ErrorMessage ="at least one Captial,Small Letter and Digits and length will be is 6-16")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Fill the Password")]
        [Compare("Password")]
        [Display(Name="Confirm Password")]       
        public string ComparePwd { get; set; }
        public bool Status { get; set; }

    }
}