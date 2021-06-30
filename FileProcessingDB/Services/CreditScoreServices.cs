using FileProcessingDB.DataModel;
using FileProcessingDB.FileProcessingDTO;
using FileProcessingDB.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileProcessingDB.Services
{
	public class CreditScoreServices: ICreditScoreServices
	{		
			public void WriteCreditScore(List<CreditScoreDTO> creditScoreDTOs)
			{
				int x = 0;
				using (FileProcessingDBContext db = new FileProcessingDBContext())
				{
					foreach (CreditScoreDTO creditScoreDTO in creditScoreDTOs)
					{
						CreditScore NewCreditScore = new CreditScore { Min = creditScoreDTOs[x].Min, Max = creditScoreDTOs[x].Max };
						db.CreditScores.Add(NewCreditScore);
						db.SaveChanges();
						x++;
					}
				}
			}		
	}
}
