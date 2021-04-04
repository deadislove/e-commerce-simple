using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Entity
{
    public class OrderManagementList
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }
    }
}
