using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Bid
    {
        //public Bid()
        //{
        //    Productions = new HashSet<Production>();
        //}

        public int ID { get; set; }

        [Display(Name = "Blueprint Code")]
        [Required(ErrorMessage = "You must enter a Blueprint Code")]
        [RegularExpression("^[A-Z\\d]{12}$", ErrorMessage = "Please enter all Capital letters.")]
        [StringLength(12, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public string BlueprintCode { get; set; }

        [Display(Name = "Estimated Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstStart { get; set; }

        [Display(Name = "Estimated End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstEnd { get; set; }

        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a Amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Amount { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "You must enter a Location")]
        [RegularExpression("^[A-Za-z\\s\\d]+$", ErrorMessage = "Please enter valid amount.")]
        public string Location { get; set; }

        //public int ProductionID { get; set; }

        //public virtual ICollection<Production> Productions { get; set; }

        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
