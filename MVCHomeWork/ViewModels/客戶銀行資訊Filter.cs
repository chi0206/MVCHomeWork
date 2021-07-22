using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeWork.ViewModels
{
    public class 客戶銀行資訊Filter
    {
        public string keyword { get; set; }

        [RegularExpression(@"(銀行名稱|銀行代碼|分行代碼|帳戶名稱|帳戶號碼|客戶資料.客戶名稱)")]
        public string sortBy { get; set; } = "客戶資料.客戶名稱";

        [RegularExpression(@"(ASC|DESC)")]
        public string sortDirection { get; set; } = "ASC";
    }
}