using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using FileProcessingDB.FileProcessingDTO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using FileProcessingDB.IServices;
using FileProcessingDB.DataModel;
using FileProcessingApplication;
using System.Linq;

namespace FileProcessingApplication
{

    public class FileProcessingParsing: IFileProcessingParsing
    {
        private readonly IAdvertiserServices advertiserServices;
        private readonly IAmountServices amountServices;
        private readonly IBaseRateServices baseRateServices;
        private readonly ICreditScoreServices creditScoreServices;
        private readonly IFileServices fileServices;
        private readonly ILtvServices ltvServices;
        private readonly IProductTypeServices productTypeServices;
        private readonly IStateServices stateServices;

        public FileProcessingParsing(IAdvertiserServices advertiserServices, IAmountServices amountServices,
            IBaseRateServices baseRateServices, ICreditScoreServices creditScoreServices, IFileServices fileServices,
            ILtvServices ltvServices, IProductTypeServices productTypeServices, IStateServices stateServices)
		{
            this.advertiserServices = advertiserServices;
            this.amountServices = amountServices;
            this.baseRateServices = baseRateServices;
            this.creditScoreServices = creditScoreServices;
            this.fileServices = fileServices;
            this.ltvServices = ltvServices;
            this.productTypeServices = productTypeServices;
            this.stateServices = stateServices;
        }

        public void OpenEXCEL()
        {
            var Amount = new List<AmountDTO>();
            var BaseRate = new List<BaseRateDTO>();
            var CreditScore = new List<CreditScoreDTO>();
            var Ltv = new List<LtvDTO>();
            var ProductType = new List<ProductTypeDTO>();
            var State = new List<StateDTO>();

            var NewAmount = new AmountDTO();
            var NewBaseRate = new BaseRateDTO();
            var NewCreditScore = new CreditScoreDTO();
            var NewLtv = new LtvDTO();
            var NewProductType = new ProductTypeDTO();
            var NewState = new StateDTO();

            var CurrEl = baseRateServices.CountCurrEl();            
            int PrTypeCell = 0;
            int StCell = 0;
            int MinLtvCell = 0;
            int MaxLtvCell = 0;
            int MinAmCell = 0;
            int MaxAmCell = 0;
            int MinCrScCell = 0;
            int MaxCrScCell = 0;
            int BRCell = 0;
            int TotTermCell = 0;
            int LastModCell = 0;

            var Advertisers = advertiserServices.GetAdvertiser();
            var Files = fileServices.GetFiles();

            Stream templateStream = new MemoryStream();
            
                        using (var Doc = new FileStream(fileServices.GetFilePath(2), FileMode.Open, FileAccess.Read))
                        {
                            var Exel = new XSSFWorkbook(Doc);
                            ISheet sheet = Exel.GetSheetAt(0);
                            int x = 1;
                            for (int y = 0; y < sheet.GetRow(0).LastCellNum; y++)
                            {
                                switch (sheet.GetRow(0).GetCell(y).ToString())
                                {
                                    case "producttype":
                                        PrTypeCell = y;
                                        break;
                                    case "state":
                                        StCell = y;
                                        break;
                                    case "minltv":
                                        MinLtvCell = y;
                                        break;
                                    case "maxltv":
                                        MaxLtvCell = y;
                                        break;
                                    case "minamount":
                                        MinAmCell = y;
                                        break;
                                    case "maxamount":
                                        MaxAmCell = y;
                                        break;
                                    case "mincreditscore":
                                        MinCrScCell = y;
                                        break;
                                    case "maxcreditscore":
                                        MaxCrScCell = y;
                                        break;
                                    case "baserate":
                                        BRCell = y;
                                        break;
                                    case "totalterm":
                                        TotTermCell = y;
                                        break;
                                    case "lastmodified":
                                        LastModCell = y;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            while (x <= sheet.LastRowNum)
                            {
                                NewProductType.Name = sheet.GetRow(x).GetCell(PrTypeCell).ToString();
                                ProductType.Add(NewProductType);
                                NewProductType = new ProductTypeDTO();

                                NewState.Name = sheet.GetRow(x).GetCell(StCell).ToString();
                                State.Add(NewState);
                                NewState = new StateDTO();

                                string MinLtv = sheet.GetRow(x).GetCell(MinLtvCell).ToString();
                                NewLtv.Min = float.Parse(MinLtv, CultureInfo.InvariantCulture.NumberFormat);
                                string MaxLtv = sheet.GetRow(x).GetCell(MaxLtvCell).ToString();
                                NewLtv.Max = float.Parse(MaxLtv, CultureInfo.InvariantCulture.NumberFormat);
                                Ltv.Add(NewLtv);
                                NewLtv = new LtvDTO();

                                string MinAmount = sheet.GetRow(x).GetCell(MinAmCell).ToString();
                                NewAmount.Min = float.Parse(MinAmount, CultureInfo.InvariantCulture.NumberFormat);
                                string MaxAmount = sheet.GetRow(x).GetCell(MaxAmCell).ToString();
                                NewAmount.Max = float.Parse(MaxAmount, CultureInfo.InvariantCulture.NumberFormat);
                                Amount.Add(NewAmount);
                                NewAmount = new AmountDTO();

                                string MinCreditScore = ParsingEmptyCells.GetCellValue(sheet.GetRow(x), MinCrScCell).ToString();
                                NewCreditScore.Min = Convert.ToInt32(MinCreditScore);
                                string MaxCreditScore = sheet.GetRow(x).GetCell(MaxCrScCell).ToString();
                                NewCreditScore.Max = Convert.ToInt32(MaxCreditScore);
                                CreditScore.Add(NewCreditScore);
                                NewCreditScore = new CreditScoreDTO();

                                string BaseRateValue = sheet.GetRow(x).GetCell(BRCell).ToString();
                                NewBaseRate.Value = float.Parse(BaseRateValue, CultureInfo.InvariantCulture.NumberFormat);
                                string TotalTerm = sheet.GetRow(x).GetCell(TotTermCell).ToString();
                                NewBaseRate.TotalTerm = Convert.ToInt32(TotalTerm);
                                string LastModified = sheet.GetRow(x).GetCell(LastModCell).ToString();
                                NewBaseRate.LastModified = Convert.ToDateTime(LastModified);
                                NewBaseRate.IdAdv = 2;
                                NewBaseRate.IdAm = CurrEl+BaseRate.Count()+1;
                                NewBaseRate.IdCr =CurrEl+BaseRate.Count()+1;
                                NewBaseRate.IdL = CurrEl+BaseRate.Count()+1;
                                NewBaseRate.IdPr = CurrEl+BaseRate.Count()+1;
                                NewBaseRate.IdSt = CurrEl+BaseRate.Count()+1;
                                BaseRate.Add(NewBaseRate);
                                NewBaseRate = new BaseRateDTO();
                                x++;                                
                            }
                        }
                   
            
            templateStream.Close();

            amountServices.WriteAmount(Amount);
            creditScoreServices.WriteCreditScore(CreditScore);
            ltvServices.WriteLtv(Ltv);
            productTypeServices.WriteProductType(ProductType);
            stateServices.WriteState(State);
            baseRateServices.WriteBaseRate(BaseRate);
        }

        public IEnumerable<BaseRate> Getall()
		{
            var myrate = baseRateServices.GetAll();            
            return myrate;
        }        
    }
}
