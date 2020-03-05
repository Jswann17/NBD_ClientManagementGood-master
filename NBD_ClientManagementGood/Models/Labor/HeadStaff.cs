using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class HeadStaff
    {
        public HeadStaff()
        {
            LabourUnits = new HashSet<LabourUnit>();
        }

        public int ID { get; set; }

        [Display(Name = "Staff Name")]
        [Required(ErrorMessage = "You cannot leave the unit name blank")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        public int LabourUnitID { get; set; }

        public virtual ICollection<LabourUnit> LabourUnits { get; set; }
    }
}
