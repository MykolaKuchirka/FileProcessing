using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;


namespace FileProcessingDB.Services
{
	public class AmountServices: IAmountServices
	{
		public void WriteAmount(float min, float max)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				Amount NewAmount = new Amount { Min = min, Max = max };
				db.Amounts.Add(NewAmount);
				db.SaveChanges();				
			}
		}
	}
}
