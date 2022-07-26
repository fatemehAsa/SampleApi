﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

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

        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        public string Password { get; set; }

        [DisplayName("تکرار کلمه عبور")]
        [Required(ErrorMessage = "فیلد {0} اجباری است")]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن مغایرت دارند")]
        public string ConfirmPassword { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        #region Relations

        public ICollection<Order> Orders { get; set; }

        #endregion



    }
}
