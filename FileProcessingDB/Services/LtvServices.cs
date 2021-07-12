using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class LtvServices : ILtvServices
	{
		private readonly FileProcessingDBContext _database;

		public LtvServices() =>
			_database = new FileProcessingDBContext();

		public void AddLtv(Ltv newLtv)
		{			
			_database.ltvs.Add(newLtv);
			_database.SaveChanges();
		}
	}
}