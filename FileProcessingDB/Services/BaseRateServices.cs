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
	
		public void WriteBaseRate(List<BaseRateDTO> baseRates)
		{			
			var Advertiser = _database.Advertisers.ToList();
			var CountAdv = Advertiser.Count();
	
			var Amount = _database.Amounts.ToList();
			var CountAm = Amount.Count();
	
			var CreditScore = _database.CreditScores.ToList();
			var CountCr = CreditScore.Count();
	
			var Ltv = _database.ltvs.ToList();
			var CountLtv = Ltv.Count();
	
			var ProductType = _database.ProductTypes.ToList();
			var CountPr = ProductType.Count();
	
			var State = _database.States.ToList();
			var CountSt = State.Count();
	
			foreach (var baseRateDTO in baseRates.Select((value, i) => new { i, value}))
			{				
				baseRateDTO.value.IdAdv = CountAdv + baseRateDTO.i - 7;
				baseRateDTO.value.IdAm = CountAm + baseRateDTO.i - 7;
				baseRateDTO.value.IdCr = CountCr + baseRateDTO.i - 7;
				baseRateDTO.value.IdL = CountLtv + baseRateDTO.i - 7;
				baseRateDTO.value.IdPr = CountPr + baseRateDTO.i - 7;
				baseRateDTO.value.IdSt = CountSt + baseRateDTO.i - 7;
			}

			var dataToSave = baseRates.Select(a => new BaseRate { Value = a.Value, TotalTerm = a.TotalTerm, 
				LastModified = a.LastModified, IDAdv =a.IdAdv, IDAm = a.IdAm, IDCr = a.IdCr, IDL = a.IdL, 
				IDPr = a.IdPr, IDSt = a.IdSt});
			_database.BaseRates.AddRange(dataToSave);
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

		public void Dispose()
		{
			_database.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}



