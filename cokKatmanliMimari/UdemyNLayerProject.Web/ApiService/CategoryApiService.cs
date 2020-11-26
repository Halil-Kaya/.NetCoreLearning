using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;


        public CategoryApiService(HttpClient httpClient){
            _httpClient = httpClient;   
        }


        public async Task<IEnumerable<CategoryDto>> GetAllAsync(){

            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("categories");

            if(response.IsSuccessStatusCode){
                
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync()); 

            }else{
                categoryDtos = null;
            }

            return categoryDtos;

        }


        public async Task<string> test(){
            
            var response = await _httpClient.GetAsync("test");
            System.Console.WriteLine(await response.Content.ReadAsStringAsync());
            return "sdafsadf";


        }

    }
}