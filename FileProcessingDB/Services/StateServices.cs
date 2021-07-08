using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class StateServices : IStateServices
	{
		private readonly FileProcessingDBContext _database;

		public StateServices() =>
			_database = new FileProcessingDBContext();

		public void WriteState(List<StateDTO> states)
		{
			var dataToSave = states.Select(a => new State { Name = a.Name });
			_database.States.AddRange(dataToSave);
			_database.SaveChanges();
		}
	}
}