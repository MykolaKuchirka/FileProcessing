using System;
using System.Collections.Generic;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class LtvServices: ILtvServices
	{
		public void WriteLtv(float min, float max)
		{
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				Ltv NewLtv = new Ltv { Min = min, Max = max };
				db.ltvs.Add(NewLtv);
				db.SaveChanges();
			}
		}
	}
}
