using Dapper;
using DBL.Entities;
using DBL.Models;
using DBL.Models.Reports.ShiftSummary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DBL.Repositories
{
    public class StationRepository : BaseRepository, IStationRepository
    {
        public StationRepository(string connectionString) : base(connectionString)
        {
        }
        #region Stations Data
        public IEnumerable<SystemStationData> GetSystemstationsData(long Tenantid, long StationId, int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantid", Tenantid);
                parameters.Add("@StationId", StationId);
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemStationData>("Usp_GetSystemStationListsData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel RegisterSystemStation(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStationData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Automatesystemstationdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Automatesystemstationdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<AutomatedStationData> Getautomatedsystemstationsdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<AutomatedStationData>("Usp_Getautomatedsystemstationsdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemstationdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStationData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemStations GetSystemStationDetailDataById(long StationId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                return connection.Query<SystemStations>("Usp_GetSystemStationDetailDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemstationdetailmodel GetSystemStationallDetailDataById(long StationId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                parameters.Add("@StationDetailData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemStationallDetailDataById", parameters, commandType: CommandType.StoredProcedure);
                string stationlistDetailsJson = parameters.Get<string>("@StationDetailData");
                if (stationlistDetailsJson != null)
                {
                    return JsonConvert.DeserializeObject<Systemstationdetailmodel>(stationlistDetailsJson);
                }
                else
                {
                    return new Systemstationdetailmodel();
                }
            }
        }
        #endregion

        #region Station Tanks
        public StationTankModel GetSystemStationTankDetailDataById(long TankId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TankId", TankId);
                return connection.Query<StationTankModel>("Usp_Getsystemtankdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterSystemStationTank(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStationTankData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Station Pump
        public Stationpumps GetSystemStationpumpDetailDataById(long PumpId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PumpId", PumpId);
                parameters.Add("@StationPumpDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystempumpdatabyid", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@StationPumpDetails");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<Stationpumps>(json);
            }
        }
        public Genericmodel RegisterSystemStationPump(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStationPumpData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Station Tanks Dips
        public Genericmodel Registersystemstationtankdipsdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationtankdipsdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StationDailyDip GetsystemstationtankdetailbyId(long TankId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TankId", TankId);
                return connection.Query<StationDailyDip>("Usp_Getsystemstationtankdetaildatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Station Purchases
        public Genericmodel Registersystemstationpurchasesdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationpurchasesdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public StationPurchase Getsystemstationpurchasesdetailbyid(long PurchaseId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PurchaseId", PurchaseId);
                parameters.Add("@SystemStationPurchasesDetailData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationpurchasesdetaildatabyid", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@SystemStationPurchasesDetailData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<StationPurchase>(json);
            }
        }
        #endregion

        #region System station Shifts

        public SingleStationShiftData Getsystemstationsingleshiftdata(long stationId, long shiftId)
        {
            SingleStationShiftData singleStationShiftData = new SingleStationShiftData();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantStationId", stationId);
                parameters.Add("@StationShiftId", shiftId);
                parameters.Add("@StationShiftDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);

                var queryResult = connection.Query("Usp_Getsystemstationshiftdatabyshiftid", parameters, commandType: CommandType.StoredProcedure);
                string detailsJson = parameters.Get<string>("@StationShiftDetails");
                
                if (detailsJson != null)
                {
                    JObject responseJson = JObject.Parse(detailsJson);
                    if (responseJson["WetstockPurchases"] != null)
                    {
                        string WetstockPurchasesJson = responseJson["WetstockPurchases"].ToString();
                        ShiftWetStockPurchaseData WetstockData = JsonConvert.DeserializeObject<ShiftWetStockPurchaseData>(WetstockPurchasesJson);
                        singleStationShiftData.WetstockPurchases = WetstockData;
                    }
                    if (responseJson["DrystockPurchases"] != null)
                    {
                        string DrystockPurchasesJson = responseJson["DrystockPurchases"].ToString();
                        ShiftDryStockPurchaseData DrystockData = JsonConvert.DeserializeObject<ShiftDryStockPurchaseData>(DrystockPurchasesJson);
                        singleStationShiftData.DrystockPurchases = DrystockData;
                    }
                    singleStationShiftData.HasPrevious = Convert.ToBoolean(responseJson["HasPrevious"]);
                    singleStationShiftData.ShiftId = Convert.ToInt64(responseJson["ShiftId"]);
                    singleStationShiftData.StationId = Convert.ToInt64(responseJson["StationId"]);
                    singleStationShiftData.LocationData = responseJson["LocationData"].ToString();
                    singleStationShiftData.ShiftCode = responseJson["ShiftCode"].ToString();
                    singleStationShiftData.ShiftCategory = responseJson["ShiftCategory"].ToString();
                    singleStationShiftData.CashOrAccount = responseJson["CashorAccount"].ToString();
                    singleStationShiftData.ShiftDateTime = Convert.ToDateTime(responseJson["ShiftDateTime"]);
                    singleStationShiftData.ShiftStatus = Convert.ToInt32(responseJson["ShiftStatus"]);
                    singleStationShiftData.IsPosted = Convert.ToBoolean(responseJson["IsPosted"]);
                    singleStationShiftData.IsDeleted = Convert.ToBoolean(responseJson["IsDeleted"]);
                    singleStationShiftData.ShiftTotalAmount = Convert.ToDecimal(responseJson["ShiftTotalAmount"]);
                    singleStationShiftData.ShiftBankedAmount = Convert.ToDecimal(responseJson["ShiftBankedAmount"]);
                    singleStationShiftData.ShiftBalance = Convert.ToDecimal(responseJson["ShiftBalance"]);
                    singleStationShiftData.ExpectedTankAmount = Convert.ToDecimal(responseJson["ExpectedTankAmount"]);
                    singleStationShiftData.ExpectedPumpAmount = Convert.ToDecimal(responseJson["ExpectedPumpAmount"]);
                    singleStationShiftData.GainLoss = Convert.ToDecimal(responseJson["GainLoss"]);
                    singleStationShiftData.PercentGainLoss = Convert.ToDecimal(responseJson["PercentGainLoss"]);
                    singleStationShiftData.ShiftBankReference = responseJson["ShiftBankReference"].ToString();
                    singleStationShiftData.ShiftReference = responseJson["ShiftReference"].ToString();
                    singleStationShiftData.Createdby = Convert.ToInt64(responseJson["Createdby"]);
                    singleStationShiftData.Modifiedby = Convert.ToInt64(responseJson["Modifiedby"]);
                    singleStationShiftData.DateCreated = Convert.ToDateTime(responseJson["DateCreated"]);
                    singleStationShiftData.DateModified = Convert.ToDateTime(responseJson["DateModified"]);
                    if (responseJson["ShiftPumpReading"] != null)
                    {
                        string ShiftPumpReadingJson = responseJson["ShiftPumpReading"].ToString();
                        List<ShiftPumpReading> ShiftPumpReadingData = JsonConvert.DeserializeObject<List<ShiftPumpReading>>(ShiftPumpReadingJson);
                        singleStationShiftData.ShiftPumpReading = ShiftPumpReadingData;
                    }
                    if (responseJson["ShiftTankReading"] != null)
                    {
                        string ShiftTankReadingJson = responseJson["ShiftTankReading"].ToString();
                        List<ShiftTankReading> ShiftTankReadingData = JsonConvert.DeserializeObject<List<ShiftTankReading>>(ShiftTankReadingJson);
                        singleStationShiftData.ShiftTankReading = ShiftTankReadingData;
                    }
                    if (responseJson["ShiftLubeReading"] != null)
                    {
                        string ShiftLubeReadingJson = responseJson["ShiftLubeReading"].ToString();
                        List<ShiftLubeReading> ShiftLubeReadingData = JsonConvert.DeserializeObject<List<ShiftLubeReading>>(ShiftLubeReadingJson);
                        singleStationShiftData.ShiftLubeReading = ShiftLubeReadingData;
                    }
                    if (responseJson["ShiftLpgReading"] != null)
                    {
                        string ShiftLpgReadingJson = responseJson["ShiftLpgReading"].ToString();
                        List<ShiftLpgReading> ShiftLpgReadingData = JsonConvert.DeserializeObject<List<ShiftLpgReading>>(ShiftLpgReadingJson);
                        singleStationShiftData.ShiftLpgReading = ShiftLpgReadingData;
                    }
                    if (responseJson["ShiftSparePartsData"] != null)
                    {
                        string ShiftSparePartsDataJson = responseJson["ShiftSparePartsData"].ToString();
                        List<ShiftSparePart> ShiftSparePartsData = JsonConvert.DeserializeObject<List<ShiftSparePart>>(ShiftSparePartsDataJson);
                        singleStationShiftData.ShiftSparePartsData = ShiftSparePartsData;
                    }
                    if (responseJson["ShiftCreditInvoice"] != null)
                    {
                        string ShiftCreditInvoiceJson = responseJson["ShiftCreditInvoice"].ToString();
                        List<ShiftCreditInvoice> ShiftCreditInvoiceData = JsonConvert.DeserializeObject<List<ShiftCreditInvoice>>(ShiftCreditInvoiceJson);
                        singleStationShiftData.ShiftCreditInvoice = ShiftCreditInvoiceData;
                    }
                    if (responseJson["ShiftExpenses"] != null)
                    {
                        string ShiftExpensesJson = responseJson["ShiftExpenses"].ToString();
                        List<ShiftExpenses> ShiftExpensesData = JsonConvert.DeserializeObject<List<ShiftExpenses>>(ShiftExpensesJson);
                        singleStationShiftData.ShiftExpenses = ShiftExpensesData;
                    }
                    if (responseJson["ShiftMpesaCollection"] != null)
                    {
                        string ShiftMpesaCollectionJson = responseJson["ShiftMpesaCollection"].ToString();
                        List<ShiftMpesaCollection> ShiftMpesaCollectionData = JsonConvert.DeserializeObject<List<ShiftMpesaCollection>>(ShiftMpesaCollectionJson);
                        singleStationShiftData.ShiftMpesaCollection = ShiftMpesaCollectionData;
                    }
                    if (responseJson["ShiftFuelCardCollection"] != null)
                    {
                        string ShiftFuelCardCollectionJson = responseJson["ShiftFuelCardCollection"].ToString();
                        List<ShiftFuelCardCollection> ShiftFuelCardCollectionData = JsonConvert.DeserializeObject<List<ShiftFuelCardCollection>>(ShiftFuelCardCollectionJson);
                        singleStationShiftData.ShiftFuelCardCollection = ShiftFuelCardCollectionData;
                    }
                    if (responseJson["ShiftMerchantCollection"] != null)
                    {
                        string ShiftMerchantCollectionJson = responseJson["ShiftMerchantCollection"].ToString();
                        List<ShiftMerchantCollection> ShiftMerchantCollectionData = JsonConvert.DeserializeObject<List<ShiftMerchantCollection>>(ShiftMerchantCollectionJson);
                        singleStationShiftData.ShiftMerchantCollection = ShiftMerchantCollectionData;
                    }
                    if (responseJson["ShiftTopup"] != null)
                    {
                        string ShiftTopupJson = responseJson["ShiftTopup"].ToString();
                        List<ShiftTopup> ShiftTopupData = JsonConvert.DeserializeObject<List<ShiftTopup>>(ShiftTopupJson);
                        singleStationShiftData.ShiftTopup = ShiftTopupData;
                    }
                    if (responseJson["ShiftPayment"] != null)
                    {
                        string ShiftPaymentJson = responseJson["ShiftPayment"].ToString();
                        List<ShiftPayment> ShiftPaymentData = JsonConvert.DeserializeObject<List<ShiftPayment>>(ShiftPaymentJson);
                        singleStationShiftData.ShiftPayment = ShiftPaymentData;
                    }
                    if (responseJson["ShiftPumpSaleSummary"] != null)
                    {
                        string ShiftPumpSaleSummaryJson = responseJson["ShiftPumpSaleSummary"].ToString();
                        List<ShiftPumpSaleSummary> ShiftPumpSaleSummaryData = JsonConvert.DeserializeObject<List<ShiftPumpSaleSummary>>(ShiftPumpSaleSummaryJson);
                        singleStationShiftData.ShiftPumpSaleSummary = ShiftPumpSaleSummaryData;
                    }
                    if (responseJson["ShiftTankSaleSummary"] != null)
                    {
                        string ShiftTankSaleSummaryJson = responseJson["ShiftTankSaleSummary"].ToString();
                        List<ShiftTankSaleSummary> ShiftTankSaleSummaryData = JsonConvert.DeserializeObject<List<ShiftTankSaleSummary>>(ShiftTankSaleSummaryJson);
                        singleStationShiftData.ShiftTankSaleSummary = ShiftTankSaleSummaryData;
                    }
                    if (responseJson["FinancialDetails"] != null)
                    {
                        string FinancialDetailsJson = responseJson["FinancialDetails"].ToString();
                        List<FinancialDetailSummary> FinancialDetailsData = JsonConvert.DeserializeObject<List<FinancialDetailSummary>>(FinancialDetailsJson);
                        singleStationShiftData.FinancialDetails = FinancialDetailsData;
                    }
                    if (responseJson["AttendantShiftSummary"] != null)
                    {
                        string AttendantShiftSummaryJson = responseJson["AttendantShiftSummary"].ToString();
                        List<AttendantShiftSummary> AttendantShiftSummaryData = JsonConvert.DeserializeObject<List<AttendantShiftSummary>>(AttendantShiftSummaryJson);
                        singleStationShiftData.AttendantShiftSummary = AttendantShiftSummaryData;
                    }
                }
                return singleStationShiftData;
            }
        }


        //public SingleStationShiftData Getsystemstationsingleshiftdata(long StationId,long ShiftId)
        //{

        //    using (var connection = new SqlConnection(_connString))
        //    {
        //        connection.Open();

        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@TenantStationId", StationId);
        //        parameters.Add("@StationShiftId", ShiftId);
        //        parameters.Add("@StationShiftDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
        //        var queryResult = connection.Query("Usp_Getsystemstationshiftdatabyshiftid", parameters, commandType: CommandType.StoredProcedure);
        //        string DetailsJson = parameters.Get<string>("@StationShiftDetails");
        //        var json = string.Format("{0}", DetailsJson);
        //        return JsonConvert.DeserializeObject<SingleStationShiftData>(json);
        //    }
        //}
        public Genericmodel Registersystemstationshiftdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationshiftpumpdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftpumpdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationshifttankdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshifttankdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationshiftlubedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftlubedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationshiftlpgdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftlpgdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationshiftsparepartdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftsparepartdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationshiftcarwashdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftcarwashdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #region Shift Credit Invoices
        public ShiftCreditInvoiceData Getsystemstationshiftcreditinvoicedata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftcreditinvoicedata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftCreditInvoiceData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftcreditinvoicedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftcreditinvoicedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Wetstock Purchase
        public ShiftWetStockPurchaseData Getsystemstationshiftwetstockpurchasedata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@ShiftWetStockPurchases", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftwetstockpurchasedata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@ShiftWetStockPurchases");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftWetStockPurchaseData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftwetstockpurchasedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftwetstockpurchasedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Drystock Purchase
        public ShiftDryStockPurchaseData Getsystemstationshiftdrystockpurchasedata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@ShiftDryStockPurchases", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftdrystockpurchasedata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@ShiftDryStockPurchases");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftDryStockPurchaseData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftdrystockpurchasedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftdrystockpurchasedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion


        #region Shift Expenses
        public ShiftExpenseData Getsystemstationshiftexpensedata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftexpensesdata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftExpenseData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftexpensedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftexpensedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Mpesa Collections 
        public ShiftMpesaCollectionData Getsystemstationshiftmpesadata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftmpesacollectiondata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftMpesaCollectionData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftmpesadata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftmpesadata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Fuel Card Collections
        public ShiftFuelCardCollectionData Getsystemstationshiftfuelcarddata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftfuelcardcollectiondata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftFuelCardCollectionData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftfuelcarddata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftfuelcarddata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Merchant Collection
        public ShiftMerchantCollectionData Getsystemstationshiftmerchantdata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftmerchantdata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftMerchantCollectionData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftmerchantdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftmerchantdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Topups
        public ShiftTopupData Getsystemstationshifttopupdata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshifttopupdata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftTopupData>(json);
            }
        }
        public Genericmodel Registersystemstationshifttopupdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshifttopupdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Shift Payments
        public ShiftPaymentData Getsystemstationshiftpaymentdata(long ShiftId, int start, int length, string? searchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@start", start);
                parameters.Add("@length", length);
                parameters.Add("@searchParam", searchParam);
                parameters.Add("@DataTableData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftpaymentdata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@DataTableData");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<ShiftPaymentData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftpaymentdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftpaymentdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        public Genericmodel Closesystemstationshiftdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Closesystemstationshiftdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Supervisorclosesystemstationshiftdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Supervisorclosesystemstationshiftdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public decimal Getsystemstationtankshiftpurchasedata(long ShiftId, long TankId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@TankId", TankId);
                return connection.Query<decimal>("Usp_Getsystemstationtankshiftpurchasedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public decimal Getsystemstationdryproductshiftpurchasedata(long ShiftId, long ProductId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftId", ShiftId);
                parameters.Add("@ProductId", ProductId);
                return connection.Query<decimal>("Usp_Getsystemstationdryproductshiftpurchasedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public decimal Getsystemstationproductpricedata(long StationId, long ProductId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                parameters.Add("@ProductId", ProductId);
                return connection.Query<decimal>("Usp_Getsystemstationproductpricedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<SystemStationShift> Getsystemstationshiftlistdata(long StationId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                return connection.Query<SystemStationShift>("Usp_Getsystemstationshiftlistdata", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public StationShiftDetailData Getsystemstationshiftdetaildata()
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Stationshiftdetaildata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemstationshiftdetaildata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@Stationshiftdetaildata");
                var json = string.Format("{0}", DetailsJson);
                return JsonConvert.DeserializeObject<StationShiftDetailData>(json);
            }
        }
        public Genericmodel Registersystemstationshiftvoucherdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationshiftvoucherdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public ShiftVoucher Getsystemstationvoucherbyid(long ShiftVoucherId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftVoucherId", ShiftVoucherId);
                return connection.Query<ShiftVoucher>("Usp_Getsystemstationvoucherdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public ShiftDetailDataModel Getsystemstationshiftdetaildata(long ShiftId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationShiftId", ShiftId);
                parameters.Add("@StationShiftDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsinglesystemstationshiftdetaildata", parameters, commandType: CommandType.StoredProcedure);
                string DetailsJson = parameters.Get<string>("@StationShiftDetails");

                // Check if DetailsJson is null
                if (DetailsJson == null)
                {
                    // Return new instance of ShiftDetailDataModel
                    return new ShiftDetailDataModel();
                }
                else
                {
                    var json = string.Format("{0}", DetailsJson);
                    return JsonConvert.DeserializeObject<ShiftDetailDataModel>(json);
                }
            }

        }
        public ProductPriceData GetsystemdryproductpricebyId(long ProductVariationId,long StationId, long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProductVariationId", ProductVariationId);
                parameters.Add("@StationId", StationId);
                parameters.Add("@CustomerId", CustomerId);
                return connection.Query<ProductPriceData>("Usp_GetsystemdryproductpricedatabyId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ProductVatPriceData GetsystemproductpricevatbyId(long SupplierId, long ProductId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SupplierId", SupplierId);
                parameters.Add("@ProductId", ProductId);
                return connection.Query<ProductVatPriceData>("Usp_GetsystemproductpricevatbyId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstationlubedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationlubedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public ShiftLubesandLpg Getsystemstationlubeandlpgbyid(long ShiftLubeLpgId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ShiftLubeLpgId", ShiftLubeLpgId);
                return connection.Query<ShiftLubesandLpg>("Usp_Getsystemstationlubeandlpgdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }


        public Genericmodel Registersystemstationcreditinvoicedata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemstationcreditinvoicedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        //public ShiftCreditInvoice Getsystemcreditinvoicesalebyid(long ShiftCreditInvoiceId)
        //{
        //    using (var connection = new SqlConnection(_connString))
        //    {
        //        connection.Open();
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@ShiftCreditInvoiceId", ShiftCreditInvoiceId);
        //        return connection.Query<ShiftCreditInvoice>("Usp_Getsystemcreditinvoicesaledatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    }
        //}
        #endregion
    }
}
