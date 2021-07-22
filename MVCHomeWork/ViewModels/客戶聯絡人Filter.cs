using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHomeWork.ViewModels
{
    public class 客戶聯絡人Filter
    {
        public string keyword { get; set; }

        [RegularExpression(@"(職稱|姓名|手機|電話|Email|客戶資料.客戶名稱)")]
        public string sortBy { get; set; } = "姓名";

        [RegularExpression(@"(ASC|DESC)")]
        public string sortDirection { get; set; } = "ASC";
    }
}