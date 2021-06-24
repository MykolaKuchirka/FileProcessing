using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class ProductType
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public List<BaseRate> baserates { get; set; }
	}
}
