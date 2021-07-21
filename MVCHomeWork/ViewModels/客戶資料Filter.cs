using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVCHomeWork.ViewModels
{
    public class 客戶資料Filter
    {
        public string keyword { get; set; }

        [RegularExpression(@"(客戶名稱|統一編號|電話|傳真|地址|Email)")]
        public string sortBy { get; set; } = "客戶名稱";

        [RegularExpression(@"(ASC|DESC)")]
        public string sortDirection { get; set; } = "ASC";
    }
}