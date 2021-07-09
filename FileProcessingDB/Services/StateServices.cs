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

		public void AddState(State newStates)
		{
			_database.States.Add(newStates);
			_database.SaveChanges();
		}
	}
}