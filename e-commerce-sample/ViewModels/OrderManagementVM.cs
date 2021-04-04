using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_sample.ViewModels
{
    public class OrderManagementVM
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PaymentStatus { get; set; }
    }
}
