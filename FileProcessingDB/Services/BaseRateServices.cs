using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileProcessingDB.Services
{
	public class BaseRateServices : IBaseRateServices
	{
		private readonly FileProcessingDBContext _database;

		public BaseRateServices() =>
			_database = new FileProcessingDBContext();
	
		public void AddBaseRate(BaseRate newBaseRate)
		{				
			_database.BaseRates.Add(newBaseRate);
			_database.SaveChanges();			
		}
		
		public IEnumerable<BaseRate> GetAll()
		{						
			var dataToReturn = _database.BaseRates.ToArray();
			return dataToReturn;
		}
		public int CountCurrEl()
		{
			int CurrEl = _database.BaseRates.ToList().Count;
			return CurrEl;
		}
	}
}



