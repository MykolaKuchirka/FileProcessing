﻿using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IProductTypeServices: IDisposable
	{
		public void WriteProductType(List<ProductTypeDTO> productTypeDTOs);
	}
}
