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

		public void AddAmount(Amount newAmount)
		{			
			_database.Amounts.Add(newAmount);
			_database.SaveChanges();
		}
	}
}