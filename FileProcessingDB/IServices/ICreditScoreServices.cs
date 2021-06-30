using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.IServices
{
	public interface ICreditScoreServices
	{
		public void WriteCreditScore(int min, int max);
	}
}
