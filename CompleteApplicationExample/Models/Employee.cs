using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompleteApplicationExample.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Fill The Employee Id")]
        [RegularExpression(@"[0-9]\d{5}",ErrorMessage ="Fill 6 Digit Employee Id ")]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Fill The Employee Name")]
        [RegularExpression(@"[a-zA-Z\s]{3,}",ErrorMessage ="Mini 3 char Required,don't allow Digits")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name="Monthly Income")]
        [DataType(DataType.Currency)]
        [Column(TypeName ="SmallMoney")]
        [Required(ErrorMessage = "Monthly Income is Required")]
        public decimal MonthlyInc { get; set; }


       [Display(Name = "Yearly Income")]
       [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public Decimal YearlyInc { get; set; }


        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Fill The Email ID")]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName ="varchar")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Start with 6,7,8,9 and (10 Digits only) ")]
        [Column(TypeName ="varchar")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [MinLength(3)]
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Address { get; set; }

        
        [Column(TypeName = "varchar")]
        [StringLength(80)]        
        public string Attachment { get; set; }

    }
}