using System.Net;

namespace RuTiKeyOne.WeatherAppWithMVVM.Model
{
    //Creating a class and method to test the Internet connection
    class InternetConnection
    {
        public static bool CheckInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("http://google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
