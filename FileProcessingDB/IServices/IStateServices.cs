using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IStateServices
	{
		public void WriteState(List<StateDTO> stateDTOs);
	}
}
