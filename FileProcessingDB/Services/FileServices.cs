using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileProcessingDB.Services
{
	public class FileServices: IFileServices
	{
		private readonly FileProcessingDBContext _database;

		public FileServices() =>
			_database = new FileProcessingDBContext();

		public int AddFile(File newFile)
		{
			var NewFile = new File { FilePath = newFile.FilePath, IDAdv = newFile.IDAdv };
			_database.Files.Add(NewFile);
			_database.SaveChanges();
			return NewFile.Id;
		}

		public string GetFilePath(int IdAdv)
		{
			var retValue = _database.Files.FirstOrDefault(f => f.IDAdv == IdAdv)?.FilePath ?? string.Empty;		
			return retValue;
		}

		public List<File> GetFiles()
		{
			return _database.Files.ToList();
		}

	}
}