using FileProcessingDB.FileProcessingDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingApplication
{
	public interface IFileProcessingParsing
	{
		public void OpenEXCEL();
		public IEnumerable<BaseRateDTO> Getall();
	}
}
