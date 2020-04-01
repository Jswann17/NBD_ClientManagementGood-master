using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Production
    {
        public Production()
        {
            Labour = new HashSet<Labour>();
            ProductionItems = new HashSet<ProductionItem>();
            LabourDepartments = new HashSet<LabourDepartment>();
        }

        public int ID { get; set; }

        [Display(Name = "Production Name")]
        [Required(ErrorMessage = "You can not leave this project name field blank")]
        [StringLength(100, ErrorMessage = "Project name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Total hourly rate")]
        //[DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public double ProHourly { get; set; }

        [Display(Name = "Total material cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public double ProMaterialCost { get; set; }

        [Display(Name = "Total cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [RegularExpression("^\\d{1,7}$", ErrorMessage = "Please enter valid amount.")]
        public double ProTotalCost { get; set; }

        public double ProBidPercent { get; set; }

        public int BidID { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual ICollection<Labour> Labour { get; set; }

        public virtual ICollection<ProductionItem> ProductionItems { get; set; }

        public virtual ICollection<LabourDepartment> LabourDepartments { get; set; }
    }
}
