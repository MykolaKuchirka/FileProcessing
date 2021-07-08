namespace FileProcessingDB.DataModel
{
	public class File
	{
		public int Id { get; set; }
		public string FilePath { get; set; }
		public int IDAdv { get; set; }

		public virtual Advertiser Advertiser { get; set; }

	}
}
