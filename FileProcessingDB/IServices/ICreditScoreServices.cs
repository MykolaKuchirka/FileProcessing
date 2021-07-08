using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface ICreditScoreServices: IDisposable
	{
		public void WriteCreditScore(List<CreditScoreDTO> creditScoreDTOs);
	}
}
