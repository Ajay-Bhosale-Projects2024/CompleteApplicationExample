using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompleteApplicationExample.Models
{
    public class Login
    {

        [StringLength(80)]
        [Required(ErrorMessage = "Fill the Email ID")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Valid Email ID")]
        public string Email { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Fill the Password")]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{6,16}", ErrorMessage = "at least one Captial,Small Letter and Digits and length will be 6-16")]
        public string Password { get; set; }
    }
}