using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileProcessingDB.FileProcessingDTO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using FileProcessingDB.Services;
using FileProcessingDB.IServices;

namespace FileProcessingApplication
{
    public class FileProcessingParsing: IFileProcessingParsing
    {
        private readonly IAdvertiserServices advertiserServices;
        private readonly IAmountServices amountServices;
        private readonly IBaseRateServices baseRateServices;
        private readonly ICreditScoreServices creditScoreServices;
        private readonly ILtvServices ltvServices;
        private readonly IProductTypeServices productTypeServices;
        private readonly IStateServices stateServices;
        public FileProcessingParsing(IAdvertiserServices advertiserServices, IAmountServices amountServices,
            IBaseRateServices baseRateServices, ICreditScoreServices creditScoreServices,
            ILtvServices ltvServices, IProductTypeServices productTypeServices, IStateServices stateServices)
		{
            this.advertiserServices = advertiserServices;
            this.amountServices = amountServices;
            this.baseRateServices = baseRateServices;
            this.creditScoreServices = creditScoreServices;
            this.ltvServices = ltvServices;
            this.productTypeServices = productTypeServices;
            this.stateServices = stateServices;
        }
        public void OpenEXCEL()
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
                    NewAdvertiser = new AdvertiserDTO();

                    NewProductType.Name = sheet.GetRow(x).GetCell(2).ToString();                    
                    ProductType.Add(NewProductType);
                    NewProductType = new ProductTypeDTO();

                    NewState.Name = sheet.GetRow(x).GetCell(3).ToString();
                    State.Add(NewState);
                    NewState = new StateDTO();

                    string MinLtv = sheet.GetRow(x).GetCell(4).ToString();
                    NewLtv.Min = float.Parse(MinLtv, CultureInfo.InvariantCulture.NumberFormat);
                    string MaxLtv = sheet.GetRow(x).GetCell(5).ToString();
                    NewLtv.Max = float.Parse(MaxLtv, CultureInfo.InvariantCulture.NumberFormat);
                    Ltv.Add(NewLtv);
                    NewLtv = new LtvDTO();

                    string MinAmount = sheet.GetRow(x).GetCell(6).ToString();
                    NewAmount.Min = float.Parse(MinAmount, CultureInfo.InvariantCulture.NumberFormat);
                    string MaxAmount = sheet.GetRow(x).GetCell(7).ToString();
                    NewAmount.Max = float.Parse(MaxAmount, CultureInfo.InvariantCulture.NumberFormat);
                    Amount.Add(NewAmount);
                    NewAmount = new AmountDTO();

                    string MinCreditScore = sheet.GetRow(x).GetCell(8).ToString();
                    NewCreditScore.Min = Convert.ToInt32(MinCreditScore);
                    string MaxCreditScore = sheet.GetRow(x).GetCell(9).ToString();
                    NewCreditScore.Max = Convert.ToInt32(MaxCreditScore);
                    CreditScore.Add(NewCreditScore);
                    NewCreditScore = new CreditScoreDTO();

                    string BaseRateValue = sheet.GetRow(x).GetCell(10).ToString();
                    NewBaseRate.Value = float.Parse(BaseRateValue, CultureInfo.InvariantCulture.NumberFormat);
                    string TotalTerm = sheet.GetRow(x).GetCell(11).ToString();
                    NewBaseRate.TotalTerm = Convert.ToInt32(TotalTerm);
                    string LastModified = sheet.GetRow(x).GetCell(12).ToString();
                    NewBaseRate.LastModified = Convert.ToDateTime(LastModified);
                    NewBaseRate.IdAdv = 1;
                    NewBaseRate.IdAm = 1;
                    NewBaseRate.IdCr = 1;
                    NewBaseRate.IdL = 1;
                    NewBaseRate.IdPr = 1;
                    NewBaseRate.IdSt = 1;
                    BaseRate.Add(NewBaseRate);
                    NewBaseRate = new BaseRateDTO();

                                       
                    //Console.WriteLine(ProductType[x-1].Name);
                    x++;
                }
                
                //foreach (ProductTypeDTO productTypeDTO in ProductType)
                //{
                //    Console.WriteLine(productTypeDTO.Name);                     
                //}
                //Console.ReadKey();
            }
            templateStream.Close();
            advertiserServices.WriteAdvertiser(Advertiser);
            amountServices.WriteAmount(Amount);
            creditScoreServices.WriteCreditScore(CreditScore);
            ltvServices.WriteLtv(Ltv);
            productTypeServices.WriteProductType(ProductType);
            stateServices.WriteState(State);
            baseRateServices.WriteBaseRate(BaseRate);
            advertiserServices.Dispose();
        }
    }
}
