using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCHomeWork.Models
{   
	public  class 客戶資料對照表Repository : EFRepository<客戶資料對照表>, I客戶資料對照表Repository
	{

	}

	public  interface I客戶資料對照表Repository : IRepository<客戶資料對照表>
	{

	}
}