using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingApplication.FileProcessingDTO
{
	public class BaseRateDTO
	{
		public float Value { get; set; }
		public DateTime LastModified { get; set; }
		public int TotalTerm { get; set; }		
	}
}
