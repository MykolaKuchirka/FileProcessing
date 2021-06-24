using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public  class ltv
	{
		public int IDl { get; set; }
		public float min { get; set; }
		public float max { get; set; }

		public List<BaseRate> baserates { get; set; }
	}
}
