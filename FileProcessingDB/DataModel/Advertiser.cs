﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class Advertiser
	{		
		public int Id { get; set; }
		public string Name { get; set; }		

		public virtual List<BaseRate> Baserates { get; set; }
	}
}
