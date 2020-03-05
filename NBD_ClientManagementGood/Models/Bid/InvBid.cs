using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Models
{
    public class InvBid
    {
        public InvBid()
        {
            Bids = new HashSet<Bid>();
            //Items = new HashSet<Item>();
        }

        public int ID { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        //public virtual ICollection<Item> Items { get; set; }
    }
}
