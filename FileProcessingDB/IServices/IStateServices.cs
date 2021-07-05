using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IStateServices: IDisposable
	{
		public void WriteState(List<StateDTO> stateDTOs);
	}
}
