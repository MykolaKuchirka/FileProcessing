using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IFileServices
	{
		public void WriteFile(List<FileDTO> fileDTOs);
		public string GetFilePath(int IdAdv);
	}
}
