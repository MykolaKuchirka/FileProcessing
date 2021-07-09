using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using FileProcessingDB.FileProcessingDTO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using FileProcessingDB.IServices;
using FileProcessingDB.DataModel;
using System.Linq;
using File = FileProcessingDB.DataModel.File;

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
            var Advertisers = advertiserServices.GetAdvertiser();
            var Files = fileServices.GetFiles();

            Stream templateStream = new MemoryStream();
            foreach (Advertiser advertiser in Advertisers)
            {
                foreach (File file in Files)
                {
                    if (advertiser.Id == file.IDAdv)
                    {
                        using (var Doc = new FileStream(fileServices.GetFilePath(file.IDAdv), FileMode.Open, FileAccess.Read))
                        {
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
                                var ProductTypeName = sheet.GetRow(x).GetCell(PrTypeCell).ToString();
                                var NewProductType = new ProductType { Name = ProductTypeName };
                                productTypeServices.AddProductType(NewProductType);

                                var StateName = sheet.GetRow(x).GetCell(StCell).ToString();
                                var NewState = new State { Name = StateName };
                                stateServices.AddState(NewState);

                                var MinLtv = float.Parse(sheet.GetRow(x).GetCell(MinLtvCell).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                var MaxLtv = float.Parse(sheet.GetRow(x).GetCell(MaxLtvCell).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                var NewLtv = new Ltv { Min = MinLtv, Max = MaxLtv };
                                ltvServices.AddLtv(NewLtv);

                                var MinAmount = float.Parse(sheet.GetRow(x).GetCell(MinAmCell).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                var MaxAmount = float.Parse(sheet.GetRow(x).GetCell(MaxAmCell).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                var NewAmount = new Amount { Min = MinAmount, Max = MaxAmount };
                                amountServices.AddAmount(NewAmount);

                                var MinCreditScore = Convert.ToInt32(ParsingEmptyCells.GetCellValue(sheet.GetRow(x), MinCrScCell).ToString());
                                var MaxCreditScore = Convert.ToInt32(sheet.GetRow(x).GetCell(MaxCrScCell).ToString());
                                var NewCreditScore = new CreditScore { Min = MinCreditScore, Max = MaxCreditScore };
                                creditScoreServices.AddCreditScore(NewCreditScore);

                                var BaseRateValue = float.Parse(sheet.GetRow(x).GetCell(BRCell).ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                var BaseRateTotalTerm = Convert.ToInt32(sheet.GetRow(x).GetCell(TotTermCell).ToString());
                                var BaseRateLastModified = Convert.ToDateTime(sheet.GetRow(x).GetCell(LastModCell).ToString());
                                var NewBaseRate = new BaseRate
                                {
                                    Value = BaseRateValue,
                                    TotalTerm = BaseRateTotalTerm,
                                    LastModified = BaseRateLastModified,
                                    IDAdv = file.IDAdv,
                                    IDAm = NewAmount.Id,
                                    IDCr = NewCreditScore.Id,
                                    IDL = NewLtv.Id,
                                    IDPr = NewProductType.Id,
                                    IDSt = NewState.Id
                                };
                                baseRateServices.AddBaseRate(NewBaseRate);
                                x++;
                            }
                        }
                    }
                }
            }                
            templateStream.Close();
        }

        public IEnumerable<BaseRate> Getall()
		{
            var myrate = baseRateServices.GetAll();            
            return myrate;
        }        
    }
}
