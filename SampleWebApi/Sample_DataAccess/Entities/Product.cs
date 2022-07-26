using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [DisplayName("نام کالا")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Color { get; set; }
        public double? Price { get; set; }

        #region Relations

        public ICollection<OrderItem> OrderItems { get; set; }

        #endregion
    }
}
