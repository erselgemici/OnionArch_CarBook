using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
        public int PricingID { get; set; }
        public virtual Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
