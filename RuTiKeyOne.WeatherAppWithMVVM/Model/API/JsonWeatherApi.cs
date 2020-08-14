using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace RuTiKeyOne.WeatherAppWithMVVM.Model.API
{
    class JsonWeatherApi
    {
        //Data storage variable
        public static WeatherResponse Wr;

        //Making a request and getting data

        #region Get data
        public static bool CreateJsonRequest(string city)
        {
            
                try
                {
                    string Url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=82630901bb3f9ed64d98d0a72e3ad275";
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    string Response;
                    using (StreamReader SR = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        Response = SR.ReadToEnd();
                    }
                    JsonWeatherApi.Wr = JsonConvert.DeserializeObject<WeatherResponse>(Response);
                return true;

                }
                catch(Exception ex)
                {
                return false;
                }
            #endregion
        
        }
    }
}
