using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileProcessingApplication.FileProcessingDTO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using FileProcessingDB.Services;

namespace FileProcessingApplication
{
    public class FileProcessingParsing
    {
        
        public static void OpenEXEL()
        {
            var Advertiser = new List<AdvertiserDTO>();
            var Amount = new List<AmountDTO>();
            var BaseRate = new List<BaseRateDTO>();
            var CreditScore = new List<CreditScoreDTO>();
            var Ltv = new List<LtvDTO>();
            var ProductType = new List<ProductTypeDTO>();
            var State = new List<StateDTO>();

            var NewAdvertiser = new AdvertiserDTO();
            var NewAmount = new AmountDTO();
            var NewBaseRate = new BaseRateDTO();
            var NewCreditScore = new CreditScoreDTO();
            var NewLtv = new LtvDTO();
            var NewProductType = new ProductTypeDTO();
            var NewState = new StateDTO();

            //var Finance = new ArrayList() { Advertiser , Amount , BaseRate , CreditScore , Ltv , ProductType , State};
            Stream templateStream = new MemoryStream();
            using (var file = new FileStream("D:\\University\\Практика ASD\\LID441.xlsx", FileMode.Open, FileAccess.Read))
            {
                var Exel = new XSSFWorkbook(file);
                ISheet sheet = Exel.GetSheetAt(0);                
                //sheet.SetAutoFilter(new CellRangeAddress(0, sheet.LastRowNum, 0, 2));
                int x = 1;                
                while (x <= sheet.LastRowNum)
                {
                    NewAdvertiser.Name = sheet.GetRow(x).GetCell(0).ToString();
                    Advertiser.Add(NewAdvertiser);
                    NewProductType.Name = sheet.GetRow(x).GetCell(2).ToString();                    
                    ProductType.Add(NewProductType);
                    NewState.Name = sheet.GetRow(x).GetCell(3).ToString();
                    State.Add(NewState);
                    string MinLtv = sheet.GetRow(x).GetCell(4).ToString();
                    NewLtv.Min = float.Parse(MinLtv, CultureInfo.InvariantCulture.NumberFormat);
                    string MaxLtv = sheet.GetRow(x).GetCell(5).ToString();
                    NewLtv.Max = float.Parse(MaxLtv, CultureInfo.InvariantCulture.NumberFormat);
                    Ltv.Add(NewLtv);
                    string MinAmount = sheet.GetRow(x).GetCell(6).ToString();
                    NewAmount.Min = float.Parse(MinAmount, CultureInfo.InvariantCulture.NumberFormat);
                    string MaxAmount = sheet.GetRow(x).GetCell(7).ToString();
                    NewAmount.Max = float.Parse(MaxAmount, CultureInfo.InvariantCulture.NumberFormat);
                    Amount.Add(NewAmount);
                    string MinCreditScore = sheet.GetRow(x).GetCell(8).ToString();
                    NewCreditScore.Min = Convert.ToInt32(MinCreditScore);
                    string MaxCreditScore = sheet.GetRow(x).GetCell(9).ToString();
                    NewCreditScore.Max = Convert.ToInt32(MaxCreditScore);
                    CreditScore.Add(NewCreditScore);
                    string BaseRateValue = sheet.GetRow(x).GetCell(10).ToString();
                    NewBaseRate.Value = float.Parse(BaseRateValue, CultureInfo.InvariantCulture.NumberFormat);
                    string TotalTerm = sheet.GetRow(x).GetCell(11).ToString();
                    NewBaseRate.TotalTerm = Convert.ToInt32(TotalTerm);
                    string LastModified = sheet.GetRow(x).GetCell(12).ToString();
                    NewBaseRate.LastModified = Convert.ToDateTime(LastModified);
                    BaseRate.Add(NewBaseRate);                    
                    x++;
                }
                
                foreach (AdvertiserDTO advertiserDTO in Advertiser)
                    Console.WriteLine(NewAdvertiser.Name);               
                
               Console.ReadKey();
            }
            templateStream.Close();
            
        }        
    }
}
