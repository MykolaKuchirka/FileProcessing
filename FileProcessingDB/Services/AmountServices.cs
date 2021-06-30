using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;


namespace FileProcessingDB.Services
{
	public class AmountServices: IAmountServices
	{
		public void WriteAmount(List<AmountDTO> amountDTOs)
		{
			int x = 0;
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				foreach (AmountDTO amountDTO in amountDTOs)
				{
					Amount NewAmount = new Amount { Min = amountDTOs[x].Min, Max = amountDTOs[x].Max };
					db.Amounts.Add(NewAmount);
					db.SaveChanges();
					x++;
				}
			}
		}
	}
}
