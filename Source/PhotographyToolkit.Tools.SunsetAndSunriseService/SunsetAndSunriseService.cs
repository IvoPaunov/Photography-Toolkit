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


        public async Task<Results> GetSunsetAndSunriseTimes(RequestModel request)
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri(ApiBaseUrl);

            var resultString = await this.GetData(request);

            return this.DeserialiseResult(resultString);
        }

        private async Task<string> GetData(RequestModel request)
        {
            string lat = request != null ? request.Latitude.ToString() : "";
            string lng = request != null ? request.Longitude.ToString() : "";
            string date = this.GetDateString(request.Date);


            var query = string.Format(QueryString, lat, lng, date);

            var response = await this.httpClient.GetAsync(query);

            return await response.Content.ReadAsStringAsync();
        }

        private Results DeserialiseResult(string resultAsString)
        {
            var result = JsonConvert.DeserializeObject<ResultModel>(resultAsString);

            return result.Results;
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
