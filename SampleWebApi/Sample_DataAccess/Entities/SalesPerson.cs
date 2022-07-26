using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_DataAccess.Entities
{
    public class SalesPerson
    {
        [Key]
        public int SalesPersonId { get; set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }

        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        [EmailAddress(ErrorMessage = "فرمت {0} اشتباه وارد شده است")]
        public string Email { get; set; }

        [DisplayName("شماره تماس")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        [Phone(ErrorMessage = "فرمت {0} اشتباه وارد شده است")]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        #region Relations

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
