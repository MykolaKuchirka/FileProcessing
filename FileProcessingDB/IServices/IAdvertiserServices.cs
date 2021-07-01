using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IAdvertiserServices: IDisposable
	{
		public void WriteAdvertiser(List<AdvertiserDTO> advertiserDTOs);		
	}
}
