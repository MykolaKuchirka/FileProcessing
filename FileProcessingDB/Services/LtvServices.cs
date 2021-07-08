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

		public void WriteLtv(List<LtvDTO> ltvs)
		{
			var dataToSave = ltvs.Select(a => new Ltv { Min = a.Min, Max = a.Max });
			_database.ltvs.AddRange(dataToSave);
			_database.SaveChanges();
		}

		public void Dispose()
		{
			_database.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}