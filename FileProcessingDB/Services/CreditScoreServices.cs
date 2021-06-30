using FileProcessingDB.DataModel;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Services
{
	public class CreditScoreServices: ICreditScoreServices
	{		
			public void WriteCreditScore(int min, int max)
			{
				using (FileProcessingDBContext db = new FileProcessingDBContext())
				{
					CreditScore NewCreditScore= new CreditScore { Min = min, Max = max };
					db.CreditScores.Add(NewCreditScore);
					db.SaveChanges();
				}
			}		
	}
}
