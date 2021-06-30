using System;
using System.Collections.Generic;
using System.Text;
using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;

namespace FileProcessingDB.Services
{
	public class LtvServices: ILtvServices
	{
		public void WriteLtv(List<LtvDTO> ltvDTOs)
		{
			int x = 0;
			using (FileProcessingDBContext db = new FileProcessingDBContext())
			{
				foreach (LtvDTO ltvDTO in ltvDTOs)
				{
					Ltv NewLtv = new Ltv { Min = ltvDTOs[x].Min, Max = ltvDTOs[x].Max };
					db.ltvs.Add(NewLtv);
					db.SaveChanges();
					x++;
				}
			}
		}
	}
}
