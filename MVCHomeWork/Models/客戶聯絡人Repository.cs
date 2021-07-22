using System;
using System.Linq;
using System.Collections.Generic;
using MVCHomeWork.ViewModels;
using System.Linq.Dynamic.Core;


namespace MVCHomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.是否已刪除 == false);
        }

        public IQueryable<客戶聯絡人> Search(客戶聯絡人Filter filter)
        {
            var data = this.All();

            if (!String.IsNullOrEmpty(filter.keyword))
            {
                data = data.Where(p => p.姓名.Contains(filter.keyword));
            }

            data = data.OrderBy(filter.sortBy + " " + filter.sortDirection);

            return data;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}