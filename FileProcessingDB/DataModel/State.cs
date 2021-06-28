using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class State
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<BaseRate> Baserates { get; set; }
	}
}
