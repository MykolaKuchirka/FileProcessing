using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IProductTypeServices
	{
		public void WriteProductType(List<ProductTypeDTO> productTypeDTOs);
	}
}
