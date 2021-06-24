using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class CreditScore
	{
		public int ID { get; set; }
		public int min { get; set; }
		public int max { get; set; }

		public List<BaseRate> baserates { get; set; }
	}
}
