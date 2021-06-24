using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.DataModel
{
	public class BaseRate
	{
		public int ID { get; set; }
		public float Value { get; set; }
		public DateTime LastModified { get; set; }
		public int TotalTerm { get; set; }

		public Advertiser Advertiser { get; set; }
		public Amount Amount { get; set; }
		public CreditScore CreditScore { get; set; }
		public ltv ltv { get; set; }
		public ProductType ProductType { get; set; }
		public State State { get; set; }

	}
}
