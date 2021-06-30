using System;
using System.Collections.Generic;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class AdvertiserServices: IAdvertiserServices
	{
		public void WriteAdvertiser(string name)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				Advertiser NewAdvertiser = new Advertiser { Name = name };
				db.Advertisers.Add(NewAdvertiser);
				db.SaveChanges();
			}
		}
	}
}
