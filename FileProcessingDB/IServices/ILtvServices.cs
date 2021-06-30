using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface ILtvServices
	{
		public void WriteLtv(List<LtvDTO> ltvDTOs);
	}
}
