using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class LabourUnit
    {
        public int ID { get; set; }

        [Display(Name = "Unit Description")]
        [Required(ErrorMessage = "You cannot leave the unit description blank")]
        [StringLength(250, ErrorMessage = "The description cannot be more than 250 characters long.")]
        public string Description { get; set; }

        [Display(Name = "Total Hours")]
        //[DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public int Hours { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public int Cost { get; set; }

        [Display(Name = "Estimated Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public int EstCost { get; set; }

        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "You cannot leave the task name blank")]
        [StringLength(100, ErrorMessage = "The task name cannot be more than 100 characters long.")]
        public string TaskName { get; set; }

        [Display(Name = "Task Description")]
        [Required(ErrorMessage = "You cannot leave the task description blank")]
        [StringLength(1000, ErrorMessage = "The description cannot be more than 1000 characters long.")]
        public string TaskDescription { get; set; }

        public int LabourDepartmentID { get; set; }

        public LabourDepartment LabourDepartment { get; set; }

        //public int HeadStaffID { get; set; }

        //public HeadStaff headStaff { get; set; }
    }
}
