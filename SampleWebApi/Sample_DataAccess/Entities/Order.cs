using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_DataAccess.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public double? Total { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonId { get; set; }


        #region Relations


        public Customer Customer { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        #endregion
    }
}
