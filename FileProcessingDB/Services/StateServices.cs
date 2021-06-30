using FileProcessingDB.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using FileProcessingDB.IServices;
using FileProcessingDB.FileProcessingDTO;

namespace FileProcessingDB.Services
{
	public class StateServices:IStateServices
	{
		public void WriteState(List<StateDTO> stateDTOs)
		{
			int x = 0;
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				foreach (StateDTO stateDTO in stateDTOs)
				{
					State NewState = new State { Name = stateDTOs[x].Name };
					db.States.Add(NewState);
					db.SaveChanges();
					x++;
				}
			}
		}
	}
}
