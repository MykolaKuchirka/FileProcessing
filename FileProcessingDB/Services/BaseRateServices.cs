using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Services
{
	public class BaseRateServices: IBaseRateServices
	{
		public void WriteBaseRate(float value, DateTime lastModified, int totalTerm, int IdAdv, int IdAm, int IdCr, int IdLlv, int IdPr, int IdSt)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				BaseRate NewBaseRate = new BaseRate { Value = value, LastModified = lastModified, TotalTerm = totalTerm, IDAdv = IdAdv, IDAm = IdAm, IDCr = IdCr, IDL = IdLlv, IDPr = IdPr, IDSt = IdSt };
				db.BaseRates.Add(NewBaseRate);
				db.SaveChanges();
			}
		}
	}
}
