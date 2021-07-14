using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeWork.ViewModels.客戶聯絡人
{
    public class 客戶聯絡人CreateViewModel
    {
        [Required]
        public int 客戶Id { get; set; }
        [Required]
        public string 職稱 { get; set; }
        [Required]
        public string 姓名 { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d{4}-\d{6}")]
        public string 手機 { get; set; }
        [Required]
        public string 電話 { get; set; }
    }
}