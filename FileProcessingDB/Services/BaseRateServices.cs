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
			int x = 0;
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
	
			foreach (BaseRateDTO baseRateDTO in baseRates)
			{
	
				baseRateDTO.IdAdv = CountAdv + x - 7;
				baseRateDTO.IdAm = CountAm + x - 7;
				baseRateDTO.IdCr = CountCr + x - 7;
				baseRateDTO.IdL = CountLtv + x - 7;
				baseRateDTO.IdPr = CountPr + x - 7;
				baseRateDTO.IdSt = CountSt + x - 7;
				
				x++;
			}
			var dataToSave = baseRates.Select(a => new BaseRate { Value = a.Value, TotalTerm = a.TotalTerm, 
				LastModified = a.LastModified, IDAdv =a.IdAdv, IDAm = a.IdAm, IDCr = a.IdCr, IDL = a.IdL, 
				IDPr = a.IdPr, IDSt = a.IdSt});
			_database.BaseRates.AddRange(dataToSave);
			_database.SaveChanges();
		}
		
		public IEnumerable<BaseRateDTO> GetAll()
		{
			var baseRate = _database.BaseRates.ToList();
			var dataToReturn = baseRate.Select(a => new BaseRateDTO
			{
				Value = a.Value,
				TotalTerm = a.TotalTerm,
				LastModified = a.LastModified,
				IdAdv = a.IDAdv,
				IdAm = a.IDAm,
				IdCr = a.IDCr,
				IdL = a.IDL,
				IdPr = a.IDPr,
				IdSt = a.IDSt
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



