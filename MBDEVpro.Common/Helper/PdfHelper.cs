
namespace MBDEVpro.Common.Helper
{
    public class PdfHelper
    {
        private readonly string _apiEndpoint;

        public PdfHelper(string apiEndpoint)
        {
            _apiEndpoint = apiEndpoint;
        }

        public class CreateDocumentModel
        {
            [RegularExpression(@"^[\x20-\x7E]*$")]
            public string Name { get; set; }

            public byte[] Document { get; set; }

            public List<byte[]> DocumentList { get; set; }
        }

        public async Task<byte[]> ConvertHtmlToPDF(string htmlContent)
        {
            CreateDocumentModel documentModel = new CreateDocumentModel { Name = htmlContent };
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            HttpResponseMessage response = await client.PostAsync(_apiEndpoint + "/ConvertHtmlToPDF", stringContent);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<byte[]>(result);
            }

            return null;
        }

        public async Task<byte[]> AddWatermarkToPDF(string fileName, string watermarkText)
        {
            CreateDocumentModel documentModel = new CreateDocumentModel { Document = System.IO.File.ReadAllBytes(fileName), Name = watermarkText };
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            HttpResponseMessage response = await client.PostAsync(_apiEndpoint + "AddWatermarkToPDF", stringContent);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<byte[]>(result);
            }

            return null;
        }

        public async Task<byte[]> ConvertHtmlToPdfWithWatermark(string htmlContent, string watermark)
        {
            var documentModel = new CreateDocumentModel { Name = htmlContent };
            var jsonContent = JsonConvert.SerializeObject(documentModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            var response = await client.PostAsync(_apiEndpoint + "/ConvertHtmlToPDF", content);

            if (response.IsSuccessStatusCode)
            {
                var pdfBytes = JsonConvert.DeserializeObject<byte[]>(await response.Content.ReadAsStringAsync());

                var watermarkModel = new CreateDocumentModel { Document = pdfBytes, Name = watermark };
                var watermarkJson = JsonConvert.SerializeObject(watermarkModel);
                var watermarkContent = new StringContent(watermarkJson, Encoding.UTF8, "application/json");
                var watermarkResponse = await client.PostAsync(_apiEndpoint + "/AddWatermarkToPDF", watermarkContent);

                if (watermarkResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<byte[]>(await watermarkResponse.Content.ReadAsStringAsync());
                }
            }

            return null;
        }

        public async Task<byte[]> ConvertWordToPDF(byte[] wordDocument, string fileName)
        {
            var documentModel = new CreateDocumentModel { Document = wordDocument, Name = fileName };
            var content = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            var response = await client.PostAsync(_apiEndpoint + "/ConvertWordToPDF", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<byte[]>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<byte[]> ConvertExcelToPDF(byte[] excelDocument, string fileName)
        {
            var documentModel = new CreateDocumentModel { Document = excelDocument, Name = fileName };
            var content = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            var response = await client.PostAsync(_apiEndpoint + "/ConvertExcelToPDF", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<byte[]>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<byte[]> ConvertPowerPointToPDF(byte[] pptDocument, string fileName)
        {
            var documentModel = new CreateDocumentModel { Document = pptDocument, Name = fileName };
            var content = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            var response = await client.PostAsync(_apiEndpoint + "/PdfSuite/ConvertPowerpointToPDF", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<byte[]>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<byte[]> MergePDFs(List<byte[]> pdfDocuments)
        {
            var documentModel = new CreateDocumentModel { DocumentList = pdfDocuments };
            var content = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");

            using var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };
            var response = await client.PostAsync(_apiEndpoint + "/MergePDFs", content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<byte[]>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}