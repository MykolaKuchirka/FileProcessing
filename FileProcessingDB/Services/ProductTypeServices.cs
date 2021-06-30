using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Services
{
	public class ProductTypeServices: IProductTypeServices
	{
		public void WriteProductType(string name)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				ProductType NewProductType = new ProductType { Name = name };
				db.ProductTypes.Add(NewProductType);
				db.SaveChanges();
			}
		}
	}
}
