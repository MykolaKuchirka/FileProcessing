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

		public void AddCreditScore(CreditScore newCreditScore)
		{
			_database.CreditScores.Add(newCreditScore);
			_database.SaveChanges();
		}		
	}
}