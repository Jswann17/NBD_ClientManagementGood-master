using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class LabourDepartment
    {
        public LabourDepartment()
        {
            LabourUnits = new HashSet<LabourUnit>();
        }

        public int ID { get; set; }

        [Display(Name = "Department Description")]
        [Required(ErrorMessage = "You cannot leave the unit description blank")]
        [StringLength(250, ErrorMessage = "The description cannot be more than 250 characters long.")]
        public string DepartmentDescription { get; set; }

        [Display(Name = "Total Hours")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "You must enter a Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public int DepartmentTotalHours { get; set; }

        public int LabourUnitID { get; set; }

        public ICollection<LabourUnit> LabourUnits { get; set; }
    }
}
