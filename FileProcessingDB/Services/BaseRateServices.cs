using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileProcessingDB.Services
{
	public class BaseRateServices: IBaseRateServices
	{
		public void WriteBaseRate(List<BaseRateDTO> baseRateDTOs)
		{
			int x = 0;
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				var Advertiser = db.Advertisers.ToList();
				var CountAdv = Advertiser.Count();

				var Amount = db.Amounts.ToList();
				var CountAm = Amount.Count();
								
				var CreditScore = db.CreditScores.ToList();
				var CountCr = CreditScore.Count();
								
				var Ltv = db.ltvs.ToList();
				var CountLtv = Ltv.Count();
								
				var ProductType = db.ProductTypes.ToList();
				var CountPr = ProductType.Count();
								
				var State = db.States.ToList();
				var CountSt = State.Count();
				

				foreach (BaseRateDTO baseRateDTO in baseRateDTOs)
				{
					
					baseRateDTOs[x].IdAdv = CountAdv + x - 7;
					baseRateDTOs[x].IdAm = CountAm + x - 7;
					baseRateDTOs[x].IdCr = CountCr + x - 7;
					baseRateDTOs[x].IdL = CountLtv + x - 7;
					baseRateDTOs[x].IdPr = CountPr + x - 7;
					baseRateDTOs[x].IdSt = CountSt + x - 7;

					BaseRate NewBaseRate = new BaseRate
					{
						Value = baseRateDTOs[x].Value,
						LastModified = baseRateDTOs[x].LastModified,
						TotalTerm = baseRateDTOs[x].TotalTerm,
						IDAdv = baseRateDTOs[x].IdAdv,
						IDAm = baseRateDTOs[x].IdAm,
						IDCr = baseRateDTOs[x].IdCr,
						IDL = baseRateDTOs[x].IdL,
						IDPr = baseRateDTOs[x].IdPr,
						IDSt = baseRateDTOs[x].IdSt						
					};
					db.BaseRates.Add(NewBaseRate);
					db.SaveChanges();
					x++;
				}
					
			}
				
		}
	}
}


