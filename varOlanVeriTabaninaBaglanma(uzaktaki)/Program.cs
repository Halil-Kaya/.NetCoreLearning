using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using varOlanVeriTabaninaBaglanma.Data.EfCore;

namespace varOlanVeriTabaninaBaglanma
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var db = new NothwindContext()){

                for(int i=0;i<50;i++){
                    

                var n = new Music(){
                    Muzisyen = "Halil KAya",
                    Tur = "Rap"
                };

                db.Music.Add(n);

                db.SaveChanges();

                }
            }


        }
    }
}
