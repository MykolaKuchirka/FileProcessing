using FileProcessingDB.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class StateServices:IStateServices
	{
		public void WriteState(string name)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				State NewState = new State { Name = name };
				db.States.Add(NewState);
				db.SaveChanges();
			}
		}
	}
}
