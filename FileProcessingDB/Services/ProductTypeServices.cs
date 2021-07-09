using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class ProductTypeServices : IProductTypeServices
	{
		private readonly FileProcessingDBContext _database;

		public ProductTypeServices() =>
			_database = new FileProcessingDBContext();

		public void WriteProductType(List<ProductTypeDTO> productTypes)
		{
			var dataToSave = productTypes.Select(a => new ProductType { Name = a.Name });
			_database.ProductTypes.AddRange(dataToSave);
			_database.SaveChanges();			
		}
	}
}