using System.Linq;
using Microsoft.AspNetCore.Mvc;
using veritabaniVeWebTest.Data.EfCore;

namespace veritabaniVeWebTest.Controllers
{
    public class HomeController : Controller
    {
        
        public string Index(){

            string usersName = "";
            using(var db = new NothwindContext()){

                var employee = db.Employees.ToList();

                employee.ForEach(u => {
                    usersName += u.FirstName + " \n";
                });


            }

            return usersName;
        }

        


        public string List(int gid){
            if(gid == 0){
                return "boyle biri yok";
            }
            int id = 2;
            string usersName = "";
            using(var db = new NothwindContext()){

                var employee = db.Employees.Where(e => e.Id == id).FirstOrDefault();
                usersName = employee.FirstName;

            }

            return usersName;
        

        }

    }
}