using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface IBaseRateServices
	{
		public void WriteBaseRate(float value, DateTime lastModified, int totalTerm, int IdAdv, int IdAm, int IdCr, int IdLlv, int IdPr, int IdSt);
	}
}
