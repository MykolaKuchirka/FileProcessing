using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class CreditScore
	{
		public int Id { get; set; }
		public int? Min { get; set; }
		public int Max { get; set; }

		public virtual List<BaseRate> Baserates { get; set; }
	}
}
