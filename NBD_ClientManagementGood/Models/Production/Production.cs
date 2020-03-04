using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class Production
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //public double ProEstHourly { get; set; }

        //public double ProEstMaterialHours { get; set; }

        //public double ProEstTotalHours { get; set; }

        //public double ProBidPercent { get; set; }

        public int BidID { get; set; }

        public virtual Bid Bid { get; set; }
    }
}
