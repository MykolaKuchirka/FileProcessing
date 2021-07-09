using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IAdvertiserServices
	{
		public void WriteAdvertiser(List<AdvertiserDTO> advertiserDTOs);
		public List<Advertiser> GetAdvertiser();

	}
}
