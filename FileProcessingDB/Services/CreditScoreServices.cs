using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class CreditScoreServices : ICreditScoreServices
	{
		private readonly FileProcessingDBContext _database;

		public CreditScoreServices() =>
			_database = new FileProcessingDBContext();

		public void WriteCreditScore(List<CreditScoreDTO> creditScores)
		{
			var dataToSave = creditScores.Select(a => new CreditScore { Min = a.Min, Max = a.Max });
			_database.CreditScores.AddRange(dataToSave);
			_database.SaveChanges();
		}

		public void Dispose()
		{
			_database.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}