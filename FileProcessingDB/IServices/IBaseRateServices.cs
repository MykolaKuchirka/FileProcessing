using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IBaseRateServices: IDisposable
	{
		public void WriteBaseRate(List<BaseRateDTO> baseRateDTOs);
		public IEnumerable<BaseRate> GetAll();		
	}
}
