using System;
using System.Linq;
using System.Collections.Generic;
using MVCHomeWork.ViewModels;
using System.Linq.Dynamic.Core;

namespace MVCHomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.是否已刪除 == false);
        }

        public IQueryable<客戶銀行資訊> Search(客戶銀行資訊Filter filter)
        {
            var data = this.All();

            if (!String.IsNullOrEmpty(filter.keyword))
            {
                data = data.Where(p => p.客戶資料.客戶名稱.Contains(filter.keyword));
            }

            data = data.OrderBy(filter.sortBy + " " + filter.sortDirection);

            return data;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}