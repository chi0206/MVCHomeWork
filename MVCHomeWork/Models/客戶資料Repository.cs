using System;
using System.Linq;
using System.Collections.Generic;
using MVCHomeWork.ViewModels;
using EntityFramework.DynamicLinq;
using System.Data.Entity;
using System.Linq.Dynamic.Core;

namespace MVCHomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.是否已刪除 == false);
        }

        public IQueryable<客戶資料> Search(客戶資料Filter filter)
        {
            var data = this.All();

            if (!String.IsNullOrEmpty(filter.keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(filter.keyword));
            }
            
            data = data.OrderBy(filter.sortBy + " " + filter.sortDirection);

            return data;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}