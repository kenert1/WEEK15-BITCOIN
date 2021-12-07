 using System;
using System.Net;


namespace BitCoinCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BitCoinRate currentBitCoin = GetRates();
            Console.WriteLine($"Current rate : {currentBitCoin.bpi.EUR.code} {currentBitCoin.bpi.EUR.rate_float}");


            Console.Write("How many bitcoins do you have? : ");
            int bitcoin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("EUR/USD/GPB);
        }

        public static BitCoinRate GetRates()
        {
            string uri = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpPWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.getResponse();
            var webStream = webResponse.GetResponseStream();

            BitCoinRate bitcoinData;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoinData = JsonConvert.DeserializeObject<BitCoinRate>(response);


            }

            return bitcoinData;




        }

    }
}
