using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using emre.Model;

namespace emre
{
    public class ChuckFactService
    : HostedService
    {
        HttpClient restClient;
        string icndbUrl="http://milletkiraathanesi.org.tr/servis.php";

 

        public ChuckFactService(){
            restClient=new HttpClient();
        }
       
        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {   
                System.Console.WriteLine("+ + +");

                var response = await restClient.GetAsync(icndbUrl, cToken);
                if (response.IsSuccessStatusCode)
                {
                    var fact = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(fact);
                    var ktphn = JsonSerializer.Deserialize<List<Kutuphane>>(fact);

 
                

                    
                    using(var db = new KutuphaneContext()){
                        db.Kutuphanes.AddRange(ktphn);
                        db.SaveChanges();
                    }

                }
    
                await Task.Delay(TimeSpan.FromSeconds(10), cToken);
            }
        }
    }
}