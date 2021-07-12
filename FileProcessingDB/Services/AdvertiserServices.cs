﻿using System.Collections.Generic;
using System.Linq;
using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{	
	public class AdvertiserServices: IAdvertiserServices
	{
		private readonly FileProcessingDBContext _database;		

		public AdvertiserServices()	 =>
			_database = new FileProcessingDBContext();	

		public int AddAdvertiser(Advertiser newAdvertiser)
		{				
			_database.Advertisers.Add(newAdvertiser);
			_database.SaveChanges();			
			return newAdvertiser.Id;
		}

		public List<Advertiser> GetAdvertisers()
		{
			return _database.Advertisers.ToList();
		}

	}
}