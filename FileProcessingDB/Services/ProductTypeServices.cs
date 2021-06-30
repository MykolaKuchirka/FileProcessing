using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Services
{
	public class ProductTypeServices: IProductTypeServices
	{
		public void WriteProductType(List<ProductTypeDTO> productTypeDTOs)
		{			
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				foreach (ProductTypeDTO productTypeDTO in productTypeDTOs)
				{
					ProductType NewProductType = new ProductType { Name = productTypeDTO.Name };
					db.ProductTypes.Add(NewProductType);
					db.SaveChanges();					
				}
			}
		}
	}
}
