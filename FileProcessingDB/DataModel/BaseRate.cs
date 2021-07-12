using System;


namespace FileProcessingDB.DataModel
{
	public class BaseRate
	{
		public int Id { get; set; }
		public float Value { get; set; }
		public DateTime LastModified { get; set; }
		public int TotalTerm { get; set; }
		public int IDAdv { get; set; }
		public int IDAm { get; set; }
		public int IDCr { get; set; }
		public int IDL { get; set; }
		public int IDPr { get; set; }
		public int IDSt { get; set; }

		public virtual Advertiser Advertiser { get; set; }
		public virtual Amount Amount { get; set; }
		public virtual CreditScore CreditScore { get; set; }
		public virtual Ltv Ltv { get; set; }
		public virtual ProductType ProductType { get; set; }
		public virtual State State { get; set; }

	}
}
