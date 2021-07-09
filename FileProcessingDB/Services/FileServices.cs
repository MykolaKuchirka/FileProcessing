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

		public void AddFile(File newFile)
		{
			var NewFile = new File { FilePath = newFile.FilePath, IDAdv = Convert.ToInt32(newFile.IDAdv.ToString()) };
			_database.Files.Add(NewFile);
			_database.SaveChanges();
		}

		public string GetFilePath(int IdAdv)
		{
			var files = _database.Files.ToList();
			string Path = "";
			foreach(File file in files)
			{
				if (IdAdv == file.IDAdv)
				{					
					Path = file.FilePath;
				}
			}			
			return Path;
		}

		public List<File> GetFiles()
		{
			return _database.Files.ToList();
		}

	}
}