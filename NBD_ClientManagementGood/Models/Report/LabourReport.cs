using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class LabourReport
    {
        public int ID { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "You cannot leave the department blank.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string Department { get; set; }

        [Display(Name = "Total Hours")]
        //[DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public int Hours { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public int Cost { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "You cannot leave the name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string Submitter { get; set; }

        [Display(Name = "SubmissionDate")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a submission date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }
    }
}
