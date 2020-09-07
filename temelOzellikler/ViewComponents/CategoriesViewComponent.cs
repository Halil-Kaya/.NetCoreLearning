using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using temelOzellikler.Models;

namespace temelOzellikler.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {

       public IViewComponentResult Invoke(){
            
            
            List<Category> categories = new List<Category>(){
                new Category(){Name = "Telefon",Description = "Telefon kategorisi"},
                new Category(){Name = "Bilgisayar",Description = "Bilgisayar kategorisi"},
                new Category(){Name = "Elektronik",Description = "Elektronik kategorisi"}
            };

            return View(categories);          
       }

    }
}