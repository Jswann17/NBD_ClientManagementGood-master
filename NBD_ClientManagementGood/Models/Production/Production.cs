using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Production
    {
        public int ID { get; set; }

        [Display(Name = "Estimated hourly rate")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public double ProEstHourly { get; set; }

        [Display(Name = "Total Material Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public double ProEstMaterialCost { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public double ProEstTotalHours { get; set; }

        public double ProBidPercent { get; set; }

        public int BidID { get; set; }

        public virtual Bid Bid { get; set; }

        public int LabourDepartmentID { get; set; }

        public virtual LabourDepartment LabourDepartment { get; set; }
    }
}
