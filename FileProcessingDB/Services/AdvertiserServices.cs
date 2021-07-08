using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{	
	public class AdvertiserServices: IAdvertiserServices
	{
		private readonly FileProcessingDBContext _database;		

		public AdvertiserServices()	 =>
			_database = new FileProcessingDBContext();	

		public void WriteAdvertiser(List<AdvertiserDTO> advertisers)
		{				
				var dataToSave = advertisers.Select(a => new Advertiser { Name = a.Name });
				_database.Advertisers.AddRange(dataToSave);
				_database.SaveChanges();
		}
	}
}