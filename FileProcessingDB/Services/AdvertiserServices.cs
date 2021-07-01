using System;
using System.Collections.Generic;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{	
	public class AdvertiserServices: IAdvertiserServices
	{
		private FileProcessingDBContext db;
		private bool disposed = false;

		public AdvertiserServices()
		{
			this.db = new FileProcessingDBContext();
		}

		public void WriteAdvertiser(List<AdvertiserDTO> advertiserDTOs)
		{				
			int x = 0;
			foreach (AdvertiserDTO advertiserDTO in advertiserDTOs)
			{
				Advertiser NewAdvertiser = new Advertiser { Name = advertiserDTOs[x].Name };
				db.Advertisers.Add(NewAdvertiser);
				db.SaveChanges();
				x++;
			}			
		}
		protected virtual void Dispose (bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					this.db.Dispose();
				}
			}
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}