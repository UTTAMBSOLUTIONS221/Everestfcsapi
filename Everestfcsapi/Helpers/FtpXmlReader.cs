using DBL;
using DBL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Everestfcsapi.Helpers
{
    public class FtpReader
    {
        private readonly BL bl;
        private readonly IConfiguration _config;

        public FtpReader(IConfiguration config)
        {
            _config = config;
            bl = new BL(Util.ShareConnectionString(_config));
        }
        public async Task ProcessXmlFromFtpAsync(string ftpServer, string ftpUsername, string ftpPassword, string ftpFolderPath)
        {
            // Connect to FTP server and retrieve files
            var ftpFiles = await GetFtpXmlFilesAsync(ftpServer, ftpUsername, ftpPassword, ftpFolderPath);

            // Process retrieved files in parallel
            await Task.WhenAll(ftpFiles.Select(file => ProcessFileAsync(file, ftpServer, ftpUsername, ftpPassword, ftpFolderPath)));
        }

        public async Task<List<string>> GetFtpXmlFilesAsync(string ftpServer, string ftpUsername, string ftpPassword, string ftpFolderPath)
        {
            List<string> xmlFileList = new List<string>();

            try
            {
                // Create URI for the FTP server
                Uri serverUri = new Uri(ftpServer);

                // Combine the base URI with the folder path
                Uri fullUri = new Uri(serverUri, ftpFolderPath);

                // Create request to list directory
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullUri);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        // Check if the file has a .xml extension
                        if (line.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        {
                            // Construct the full path of the file by appending to the subfolder
                            string fullPath = ftpFolderPath.TrimEnd('/') + "/" + line;
                            xmlFileList.Add(fullPath);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle exception (e.g., log error, throw exception)
                Console.WriteLine($"Error accessing FTP directory: {ex.Message}");
            }

            return xmlFileList;
        }

        private async Task ProcessFileAsync(string fileName, string ftpServer, string ftpUsername, string ftpPassword,string folderPath)
        {
            try
            {
                string fullFtpUri = ftpServer + fileName;
                string fileContent = await ReadFileContentFromFtpAsync(fullFtpUri, ftpUsername, ftpPassword);
                if (!string.IsNullOrEmpty(fileContent))
                {
                    // Process file content
                    ProcessFileContent(fileContent, folderPath);

                    // Delete the file from the FTP server after processing
                    await DeleteFileFromFtpAsync(fileName, ftpServer, ftpUsername, ftpPassword);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error)
                Console.WriteLine($"Error processing file {fileName}: {ex.Message}");
            }
        }

        private async Task<string> ReadFileContentFromFtpAsync(string ftpUri, string username, string password)
        {
            try
            {
                // Create request to download file
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);

                // Read the file content asynchronously
                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (WebException ex)
            {
                // Handle exception (e.g., log error)
                Console.WriteLine($"Error reading file from FTP: {ex.Message}");
                return null;
            }
        }

        private async Task DeleteFileFromFtpAsync(string fileName, string ftpServer, string username, string password)
        {
            try
            {
                string fullFtpUri = ftpServer + fileName;
                // Create URI for the FTP server
                Uri serverUri = new Uri(ftpServer);

                // Combine the base URI with the file name
                Uri fullUri = new Uri(serverUri, fileName);

                // Create request to delete file
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fullUri);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(username, password);

                using (FtpWebResponse response = (FtpWebResponse)await request.GetResponseAsync())
                {
                    Console.WriteLine($"File deleted: {fileName}");
                }
            }
            catch (WebException ex)
            {
                // Handle exception (e.g., log error)
                Console.WriteLine($"Error deleting file from FTP: {ex.Message}");
            }
        }

        private void ProcessFileContent(string fileContent,string ftpFolderPath)
        {
            try
            {
                AutomationTransactionData model = new AutomationTransactionData();
                // Load XML content into XmlDocument
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(fileContent);

                // Access XML nodes and process data
                XmlNodeList trnNodes = xmlDoc.SelectNodes("//TRN");
                foreach (XmlNode trnNode in trnNodes)
                {
                    string EfdId = trnNode.Attributes["EFD_ID"]?.Value;
                    string RegId = trnNode.Attributes["REG_ID"]?.Value;
                    string FdcNum = trnNode.Attributes["FDC_NUM"]?.Value;
                    string FdcName = trnNode.Attributes["FDC_NAME"]?.Value;
                    string RdgSaveNum = trnNode.Attributes["RDG_SAVE_NUM"]?.Value;
                    string FdcSaveNum = trnNode.Attributes["FDC_SAVE_NUM"]?.Value;
                    string RdgDate = trnNode.Attributes["RDG_DATE"]?.Value;
                    string RdgTime = trnNode.Attributes["RDG_TIME"]?.Value;
                    string FdcDate = trnNode.Attributes["FDC_DATE"]?.Value;
                    string FdcTime = trnNode.Attributes["FDC_TIME"]?.Value;
                    string RdgIndex = trnNode.Attributes["RDG_INDEX"]?.Value;
                    string RdgId = trnNode.Attributes["RDG_ID"]?.Value;
                    string Fp = trnNode.Attributes["FP"]?.Value;
                    string PumpAddr = trnNode.Attributes["PUMP_ADDR"]?.Value;
                    string Noz = trnNode.Attributes["NOZ"]?.Value;
                    string Price = trnNode.Attributes["PRICE"]?.Value;
                    string Vol = trnNode.Attributes["VOL"]?.Value;
                    string Amo = trnNode.Attributes["AMO"]?.Value;
                    string VolTotal = trnNode.Attributes["VOL_TOTAL"]?.Value;
                    string RoundType = trnNode.Attributes["ROUND_TYPE"]?.Value;
                    string RdgProd = trnNode.Attributes["RDG_PROD"]?.Value;
                    string FdcProd = trnNode.Attributes["FDC_PROD"]?.Value;
                    string FdcProdName = trnNode.Attributes["FDC_PROD_NAME"]?.Value;
                    string FdcTank = trnNode.Attributes["FDC_TANK"]?.Value;
                    model.FtpFolderPath = ftpFolderPath;
                    model.Transaction = new AutomationTransaction
                    {
                        EfdId = EfdId,
                        RegId = RegId,
                        FdcNum = Convert.ToInt64(FdcNum),
                        FdcName = FdcName,
                        RdgSaveNum = Convert.ToInt64(RdgSaveNum),
                        FdcSaveNum = Convert.ToInt64(FdcSaveNum),
                        RdgDate = Convert.ToDateTime(RdgDate),
                        RdgTime = RdgTime,
                        FdcDate = Convert.ToDateTime(RdgDate),
                        FdcTime = FdcTime,
                        RdgIndex = Convert.ToInt64(RdgIndex),
                        RdgId = Convert.ToInt64(RdgId),
                        Fp = Convert.ToInt64(Fp),
                        PumpAddr = Convert.ToInt64(PumpAddr),
                        Noz = Convert.ToInt64(Noz),
                        Price = Convert.ToDecimal(Price),
                        Vol = Convert.ToDecimal(Vol),
                        Amo = Convert.ToDecimal(Amo),
                        VolTotal = Convert.ToDecimal(VolTotal),
                        RoundType = Convert.ToInt64(RoundType),
                        RdgProd = Convert.ToInt64(RdgProd),
                        FdcProd = Convert.ToInt64(FdcProd),
                        FdcProdName = FdcProdName,
                        FdcTank = FdcTank
                    };
                }

                XmlNodeList rfidCardNodes = xmlDoc.SelectNodes("//RFID_CARD");
                foreach (XmlNode rfidCardNode in rfidCardNodes)
                {
                    string used = rfidCardNode.Attributes["USED"]?.Value;
                    string cardType = rfidCardNode.Attributes["CARD_TYPE"]?.Value;
                    string Used = rfidCardNode.Attributes["USED"]?.Value;
                    string CardType = rfidCardNode.Attributes["CARD_TYPE"]?.Value;
                    string Num = rfidCardNode.Attributes["NUM"]?.Value;
                    string Num10 = rfidCardNode.Attributes["NUM_10"]?.Value;
                    string CustName = rfidCardNode.Attributes["CUST_NAME"]?.Value;
                    string CustIdType = rfidCardNode.Attributes["CUST_IDTYPE"]?.Value;
                    string CustId = rfidCardNode.Attributes["CUST_ID"]?.Value;
                    string CustContact = rfidCardNode.Attributes["CUST_CONTACT"]?.Value;
                    string PayMethod = rfidCardNode.Attributes["PAY_METHOD"]?.Value;
                    string DiscountType = rfidCardNode.Attributes["DISCOUNT_TYPE"]?.Value;
                    string Discount = rfidCardNode.Attributes["DISCOUNT"]?.Value;
                    string ProductEnabled = rfidCardNode.Attributes["PRODUCT_ENABLED"]?.Value;
                    model.RFIDCard = new RFIDCard
                    {
                        Used = Convert.ToInt64(Used),
                        CardType = Convert.ToInt64(CardType),
                        Num = Num,
                        Num10 = Num10,
                        CustName = CustName,
                        CustIdType = Convert.ToInt64(CustIdType),
                        CustId = Convert.ToInt64(CustId),
                        CustContact = CustContact,
                        PayMethod = Convert.ToInt64(DiscountType),
                        DiscountType = Convert.ToInt64(PayMethod),
                        Discount = Convert.ToDecimal(PayMethod),
                        ProductEnabled = ProductEnabled,
                    };
                }
                // Process DISCOUNT nodes
                XmlNodeList discountNodes = xmlDoc.SelectNodes("//DISCOUNT");
                foreach (XmlNode discountNode in discountNodes)
                {
                    string DiscountType = discountNode.Attributes["DISCOUNT_TYPE"]?.Value;
                    string PriceOrigin = discountNode.Attributes["PRICE_ORIGIN"]?.Value;
                    string PriceNew = discountNode.Attributes["PRICE_NEW"]?.Value;
                    string PriceDiscount = discountNode.Attributes["PRICE_DISCOUNT"]?.Value;
                    string VolOrigin = discountNode.Attributes["VOL_ORIGIN"]?.Value;
                    string AmoOrigin = discountNode.Attributes["AMO_ORIGIN"]?.Value;
                    string AmoNew = discountNode.Attributes["AMO_NEW"]?.Value;
                    string AmoDiscount = discountNode.Attributes["AMO_DISCOUNT"]?.Value;
                    model.Discount = new Discount
                    {
                        DiscountType = Convert.ToInt64(DiscountType),
                        PriceOrigin = Convert.ToDecimal(PriceOrigin),
                        PriceNew = Convert.ToDecimal(PriceNew),
                        PriceDiscount = Convert.ToDecimal(PriceDiscount),
                        VolOrigin = Convert.ToDecimal(VolOrigin),
                        AmoOrigin = Convert.ToDecimal(AmoOrigin),
                        AmoNew = Convert.ToDecimal(AmoNew),
                        AmoDiscount = Convert.ToDecimal(AmoDiscount),
                    };
                }
               //process the automation data to database
                var resp = bl.ProcessAutomationsalesData(JsonConvert.SerializeObject(model));
                Console.WriteLine("XML file processed successfully.");
            }
            catch (XmlException ex)
            {
                // Handle XML parsing errors
                Console.WriteLine($"Error parsing XML content: {ex.Message}");
            }
        }
    }
}
