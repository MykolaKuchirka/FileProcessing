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
		public void WriteAdvertiser(List<AdvertiserDTO> advertiserDTOs)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
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
		}
	}
}
