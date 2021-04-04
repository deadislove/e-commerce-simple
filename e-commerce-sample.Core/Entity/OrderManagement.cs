using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Core.Entity
{
    [Table("OrderManagements")]
    public class OrderManagement
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool Status { get; set; }
    }
}
