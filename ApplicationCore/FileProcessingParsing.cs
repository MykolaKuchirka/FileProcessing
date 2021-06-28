using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.Native;
using FileProcessingApplication.FileProcessingDTO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace FileProcessingApplication
{
    public class FileProcessingParsing
    {
        public static void Main(string[] args)
        {
            OpenEXEL();
        }
        private static void OpenEXEL()
        {
            var Advertiser = new List<AdvertiserDTO>();
            var Amouno = new List<AmountDTO>();
            var BaseRate = new List<BaseRateDTO>();
            var CreditScore = new List<CreditScoreDTO>();
            var Ltv = new List<LtvDTO>();
            var ProductType = new List<ProductTypeDTO>();
            var State = new List<StateDTO>();
            Stream templateStream = new MemoryStream();
            using (var file = new FileStream("D:\\University\\Практика ASD\\LID441.xlsx", FileMode.Open, FileAccess.Read))
            {
                var Exel = new XSSFWorkbook(file);
                ISheet sheet = Exel.CreateSheet("Read") as XSSFSheet;
                int x = 1;
                //while (x <= sheet.LastRowNum)
                //{
                //    IRow row = sheet1.GetRow(x.Cell);
                //    row.GetCell(x.Cell).SetCellValue(x.Value);
                //}
                AdvertiserDTO.Name = Exel.GetSheetAt(0).GetRow(1).GetCell(0).ToString();                
                ProductTypeDTO.Name = Exel.GetSheetAt(0).GetRow(1).GetCell(2).ToString();
                StateDTO.Name = Exel.GetSheetAt(0).GetRow(1).GetCell(3).ToString();
                string MinLtv = Exel.GetSheetAt(0).GetRow(1).GetCell(4).ToString();
                LtvDTO.Min = float.Parse(MinLtv, CultureInfo.InvariantCulture.NumberFormat);
                string MaxLtv = Exel.GetSheetAt(0).GetRow(1).GetCell(5).ToString();
                string MinAmount = Exel.GetSheetAt(0).GetRow(1).GetCell(6).ToString();
                AmountDTO.Min = float.Parse(MinAmount, CultureInfo.InvariantCulture.NumberFormat);
                string MaxAmount = Exel.GetSheetAt(0).GetRow(1).GetCell(7).ToString();
                AmountDTO.Max = float.Parse(MaxAmount, CultureInfo.InvariantCulture.NumberFormat);
                LtvDTO.Max = float.Parse(MaxLtv, CultureInfo.InvariantCulture.NumberFormat);
                string MinCreditScore = Exel.GetSheetAt(0).GetRow(1).GetCell(8).ToString();
                CreditScoreDTO.Min = Convert.ToInt32(MinCreditScore);
                string MaxCreditScore = Exel.GetSheetAt(0).GetRow(1).GetCell(9).ToString();
                CreditScoreDTO.Max = Convert.ToInt32(MaxCreditScore);
                string BaseRateValue = Exel.GetSheetAt(0).GetRow(1).GetCell(10).ToString();
                BaseRateDTO.Value = float.Parse(BaseRateValue, CultureInfo.InvariantCulture.NumberFormat);
                string TotalTerm = Exel.GetSheetAt(0).GetRow(1).GetCell(11).ToString();
                BaseRateDTO.TotalTerm = Convert.ToInt32(TotalTerm);
                string LastModified = Exel.GetSheetAt(0).GetRow(1).GetCell(12).ToString();
                BaseRateDTO.LastModified = Convert.ToDateTime(LastModified);
                Console.WriteLine("Advertiser - "+AdvertiserDTO.Name+" ProductType = "+ProductTypeDTO.Name
                    + " State = " + StateDTO.Name+" State = "+ StateDTO.Name + " Min ltv = " + LtvDTO.Min 
                    + " Max ltv = " + LtvDTO.Max+ " Min amount = "+ AmountDTO.Min+ " Max amount = " + AmountDTO.Max
                    + " Min CreditScore = " + CreditScoreDTO.Min + " Max CreditScore = " + CreditScoreDTO.Max
                    + " BaseRate = " + BaseRateDTO.Value+ " TotalTerm = " + BaseRateDTO.TotalTerm+" Last Modified = "+ BaseRateDTO.LastModified);
                Console.ReadKey();
            }
            //var templateWorkbook = new XSSFWorkbook(templateStream);
            //var sheet = templateWorkbook.GetSheetAt(0);
            //ISheet sheet = templateWorkbook.CreateSheet("Test") as XSSFSheet;
            //sheet.SetAutoFilter(new CellRangeAddress(0, sheet.LastRowNum, 0, 2));

            //var fileStream = new FileStream("D:\\moban2.xls", FileMode.Create);
            //templateWorkbook.Write(fileStream);
            //fileStream.Close();
            //Console.WriteLine(templateWorkbook.GetSheetAt(0).PhysicalNumberOfRows);




            //using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            //{              
            //                            
            //    foreach (var x in celldata)
            //    {
            //        IRow row = sheet1.GetRow(x.Cell);
            //        row.GetCell(x.Cell).SetCellValue(x.Value);
            //    }
            //}
        }
    }
}
