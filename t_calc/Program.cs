using System;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace t_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient(new HttpClientHandler());
            
            
            var resultus = client.GetAsync("http://localhost:5001/500+500").Result;
            var result_ = resultus.Headers.Where(x => x.Key == "result");
            Console.WriteLine(result_);
             
        }
    }
}