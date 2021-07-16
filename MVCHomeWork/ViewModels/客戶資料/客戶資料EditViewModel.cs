using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeWork.ViewModels.客戶資料
{
    public class 客戶資料EditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string 客戶名稱 { get; set; }
        [Required]
        public string 統一編號 { get; set; }
        [Required]
        public string 電話 { get; set; }
        [Required]
        public string 傳真 { get; set; }
        [Required]
        public string 地址 { get; set; }
        [Required]
        public string Email { get; set; }
    }
}