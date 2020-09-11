using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace temelOzellikler.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {

       public IViewComponentResult Invoke(){

           

            return View();          
       
       }

    }
}