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
            LabourStaffs = new HashSet<LabourStaff>();
            Productions = new HashSet<Production>();
            //ProjectTeams = new HashSet<ProjectTeam>();
        }

        public int ID { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "You can not leave this project name field blank")]
        [StringLength(100, ErrorMessage = "Project name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Department Description")]
        [Required(ErrorMessage = "You cannot leave the unit description blank")]
        [StringLength(250, ErrorMessage = "The description cannot be more than 250 characters long.")]
        public string DepartmentDescription { get; set; }

        public ICollection<LabourStaff> LabourStaffs { get; set; }

        public virtual ICollection<Production> Productions { get; set; }

        //public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
    }
}
