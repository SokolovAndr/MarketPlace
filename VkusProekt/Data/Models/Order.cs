using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace VkusProekt.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage ="Слишком короткое имя")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Слишком короткая фамилия")]
        public string surname { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Слишком короткий адрес")]
        public string adress { get; set; }
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Слишком короткий телефон")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Слишком короткий Email")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
