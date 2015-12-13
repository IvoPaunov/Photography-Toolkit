namespace PhotographyToolkit.Tools.SunsetAndSunriseService
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using PhotographyToolkit.Tools.SunsetAndSunriseService.Models;

    public class SunsetAndSunriseService
    {
        private const string ApiBaseUrl = "http://api.sunrise-sunset.org/json";
        private const string QueryString = "?lat={0}&lng={1}&date={2}&formatted=0";

        private HttpClient httpClient;


        public async Task<SunSetRiseResults> GetSunsetAndSunriseTimes(double latitude, double longtitude, DateTime? date )
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(ApiBaseUrl);

            var requestModel = new SunSetRiseRequestModel(latitude, longtitude, date);

            var resultString = await this.GetData(requestModel);

            return this.DeserialiseResult(resultString);
        }

        private async Task<string> GetData(SunSetRiseRequestModel sunSetRiseRequest)
        {
            string lat = sunSetRiseRequest != null ? sunSetRiseRequest.Latitude.ToString() : "";
            string lng = sunSetRiseRequest != null ? sunSetRiseRequest.Longitude.ToString() : "";
            string date = this.GetDateString(sunSetRiseRequest.Date);


            var query = string.Format(QueryString, lat, lng, date);

            var response = await this.httpClient.GetAsync(query);

            return await response.Content.ReadAsStringAsync();
        }

        private SunSetRiseResults DeserialiseResult(string resultAsString)
        {
            var result = JsonConvert.DeserializeObject<ResultModel>(resultAsString);

            return result.SunSetRiseResults;
        }

        private string GetDateString(DateTime? date)
        {
            if (date == null)
            {
                return "today";
            }

            var notNullDate = date.Value;

            return notNullDate.Year + "-" + notNullDate.Month + "-" + notNullDate.Day;
        }
    }
}
