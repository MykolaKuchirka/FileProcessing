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
			var baseRate = _database.BaseRates.ToList();
			var Advertisers = _database.Advertisers.ToList();
			var Amounts = _database.Amounts.ToList();
			var CreditScores = _database.CreditScores.ToList();
			var Ltvs = _database.ltvs.ToList();
			var ProductTypes = _database.ProductTypes.ToList();
			var States = _database.States.ToList();
			var dataToReturn = baseRate.Select(a => new BaseRate
			{
				Value = a.Value,
				TotalTerm = a.TotalTerm,
				LastModified = a.LastModified,				
				IDAdv = a.IDAdv,
				IDAm = a.IDAm,
				IDCr = a.IDCr,
				IDL = a.IDL,
				IDPr = a.IDPr,
				IDSt = a.IDSt,
				Advertiser = Advertisers.First(o => o.Id == a.IDAdv),
				Amount = Amounts.First(o => o.Id == a.IDAm),
				CreditScore = CreditScores.First(o => o.Id == a.IDCr),
				Ltv = Ltvs.First(o => o.Id == a.IDL),
				ProductType = ProductTypes.First(o => o.Id == a.IDPr),
				State = States.First(o => o.Id == a.IDSt)
			});
			return dataToReturn;
		}
		public int CountCurrEl()
		{
			int CurrEl = _database.BaseRates.ToList().Count;
			return CurrEl;
		}
	}
}



