using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class BidLB
    {
        public BidLB()
        {
            Bids = new HashSet<Bid>();
            LabourUnits = new HashSet<LabourUnit>();
        }

        public int ID { get; set; }

        public int BidID { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public int LabourUnitID { get; set; }

        public virtual ICollection<LabourUnit> LabourUnits { get; set; }
    }
}
