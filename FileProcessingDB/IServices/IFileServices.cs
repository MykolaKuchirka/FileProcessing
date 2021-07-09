using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IFileServices
	{
		public void AddFile(File newFile);
		public string GetFilePath(int IdAdv);
		public List<File> GetFiles();
	}
}
