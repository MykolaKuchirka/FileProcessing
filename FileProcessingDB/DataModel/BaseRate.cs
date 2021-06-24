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
		public int IDAdv { get; set; }
		public int IDAm { get; set; }
		public int IDCr { get; set; }
		public int IDl { get; set; }
		public int IDPr { get; set; }
		public int IDSt { get; set; }
		public virtual Advertiser Advertiser { get; set; }
		public virtual Amount Amount { get; set; }
		public virtual CreditScore CreditScore { get; set; }
		public virtual ltv ltv { get; set; }
		public virtual ProductType ProductType { get; set; }
		public virtual State State { get; set; }

	}
}
