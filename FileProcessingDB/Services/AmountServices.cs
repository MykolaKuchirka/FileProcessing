using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class AmountServices : IAmountServices
	{
		private readonly FileProcessingDBContext _database;

		public AmountServices() =>
			_database = new FileProcessingDBContext();

		public void WriteAmount(List<AmountDTO> amounts)
		{
			foreach(AmountDTO currentamount in amounts)
			{
				var NewAmount = new Amount { Min = currentamount.Min, Max = currentamount.Max };
				_database.Amounts.AddRange(NewAmount);
				_database.SaveChanges();
			}
			//var dataToSave = amounts.Select(a => new Amount { Min = a.Min, Max = a.Max });
			//_database.Amounts.AddRange(dataToSave);
			//_database.SaveChanges();
		}
	}
}