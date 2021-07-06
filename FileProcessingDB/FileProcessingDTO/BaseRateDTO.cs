using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessingDB.FileProcessingDTO
{
	public class BaseRateDTO
	{
		public float Value { get; set; }
		public DateTime LastModified { get; set; }
		public int TotalTerm { get; set; }
		public int IdAdv { get; set; }
		public int IdAm { get; set; }
		public int IdCr { get; set; }
		public int IdL { get; set; }
		public int IdPr { get; set; }
		public int IdSt { get; set; }
	}
}
