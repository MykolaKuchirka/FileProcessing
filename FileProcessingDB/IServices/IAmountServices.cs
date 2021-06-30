using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IAmountServices
	{
		public void WriteAmount(List<AmountDTO> amountDTOs);
	}
}
