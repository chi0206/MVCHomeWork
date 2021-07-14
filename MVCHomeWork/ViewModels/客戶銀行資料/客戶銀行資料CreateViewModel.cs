using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeWork.ViewModels.客戶銀行資料
{
    public class 客戶銀行資料CreateViewModel
    {
        [Required]
        public int 客戶Id { get; set; }
        [Required]
        public string 銀行名稱 { get; set; }
        [Required]
        public int 銀行代碼 { get; set; }
        [Required]
        public Nullable<int> 分行代碼 { get; set; }
        [Required]
        public string 帳戶名稱 { get; set; }
        [Required]
        public string 帳戶號碼 { get; set; }
    }
}