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

		public void WriteFile(List<FileDTO> files)
		{
			var Advertiser = _database.Advertisers.ToList();
			var CountAdv = Advertiser.Count();
			
			var dataToSave = files.Select(a => new File
			{
				FilePath = a.FilePath,				
				IDAdv = a.IDAdv,
				
			});
			_database.Files.AddRange(dataToSave);
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
	}
}