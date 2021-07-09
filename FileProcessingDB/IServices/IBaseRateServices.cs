using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IBaseRateServices
	{
		public void AddBaseRate(BaseRate newBaseRate);
		public IEnumerable<BaseRate> GetAll();
		public int CountCurrEl();
	}
}
