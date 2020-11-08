using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UdemyApiWithToken.Extensions
{
    public static class ModelStateExtensions
    {
        
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary){
            return dictionary.SelectMany(m => m.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }

    }
}