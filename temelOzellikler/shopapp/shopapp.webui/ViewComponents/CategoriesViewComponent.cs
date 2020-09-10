using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using temelOzellikler.Data;
using temelOzellikler.Models;

namespace temelOzellikler.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {

       public IViewComponentResult Invoke(){

           if(RouteData.Values["action"].ToString() == "List"){
                ViewBag.SelectedCategory = RouteData?.Values["id"];
           }

            return View(CategoryRepository.Categories);          
       
       }

    }
}