using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Item
    {
        public Item()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Display(Name = "Inventory Code")]
        [Required(ErrorMessage = "You must enter a Inventory Code")]
        [RegularExpression("^[A-Z\\d]{12}$", ErrorMessage = "Please enter all Capital letters.")]
        [StringLength(256, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public string Code { get; set; }

        [Display(Name = "Inventory Size")]
        [Required(ErrorMessage = "You must pick a size")]
        public string Size { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "You must enter a Number")]
        [RegularExpression("^\\d{0,5}$", ErrorMessage = "5 numbers max")]
        [StringLength(12, ErrorMessage = "Blueprint Code must be 12 Characters long")]
        public int Qty { get; set; }

        [Display(Name = "Per unit")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Net { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter a amount")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int TotalCost { get; set; }

        [Display(Name = "Estimated Delivery Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a delivery Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public int DeliveryDate { get; set; }

        [Display(Name = "Estimated install Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a install date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public int InstallDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public int InvBidID { get; set; }

        public virtual InvBid InvBid { get; set; }
    }
}
