using System.Collections.Generic;
using System.Linq;
using temelOzellikler.Models;

namespace temelOzellikler.Data
{
    public static class CategoryRepository
    {
        private static List<Category> _categories = null;

        static CategoryRepository(){

            _categories = new List<Category>(){
                new Category(){CategoryId = 1,Name = "Telefon",Description = "Telefon kategorisi"},
                new Category(){CategoryId = 2,Name = "Bilgisayar",Description = "Bilgisayar kategorisi"},
                new Category(){CategoryId = 3,Name = "Elektronik",Description = "Elektronik kategorisi"}
            };

        }

        public static List<Category> Categories{
             get{
                 return _categories;
            }
        }

        public static void AddCategory(Category category){
            _categories.Add(category);
        }

        public static Category GetCategoryById(int id){

            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }

    }
}