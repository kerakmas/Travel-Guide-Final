
Console.WriteLine("Asslomu Aleykum Men Http client dan foydalanib agar siz Davlat poytaxti nomini kiritez qasyi davlatnikiligini topib beradi. pasdagi commentga olingan kodni commentdan ochib ishlatishingiz mumkin meni projectim travel guide bulganligi uchun shu api ni topdim. bu httpl clinetdan tashqar oldingi projectim entity framework bilan databsaga mosladim uni ham ishlatib kurishingiz mumkin.");



//using System;
//using System.Net.Http;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        using (var client = new HttpClient())
//        {
//            Console.Write("Poytaxt nomini kiriting ");
//            string capitalCity = Console.ReadLine();
//            HttpResponseMessage response = await client.GetAsync($"https://restcountries.com/v3.1/capital/{capitalCity}");
//            if (response.IsSuccessStatusCode)
//            {
//                string responseContent = await response.Content.ReadAsStringAsync();
//                dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
//                string country = responseObject[0].name.common;
//                Console.WriteLine($"{capitalCity} is the capital city of {country}.");
//            }
//            else
//            {
//                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
//            }
//        }
//    }
//}
