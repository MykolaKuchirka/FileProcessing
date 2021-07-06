using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class Amount
	{
		public int Id { get; set; }
		public float Min { get; set; }
		public float Max { get; set; }

		public virtual List<BaseRate> Baserates { get; set; }
	}
}
