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


                //bütün elemanları getirme:
                var allEmployees = db.Employees.ToList();

                allEmployees.ForEach(e => {
                    System.Console.WriteLine(e.Company + "  " + e.FirstName);
                });


                //id ye göre getirme
                var employee = db.Employees.Where(e => e.Id == 1).FirstOrDefault();
                System.Console.WriteLine(employee.Company + " " + employee.FirstName);


                //sadece belirli kisimlari getirme:
                var employee = db.Employees
                .Select(e => new {
                    e.FirstName,
                    e.LastName
                })
                .ToList();

                employee.ForEach(e => {
                    System.Console.WriteLine(e.FirstName + " " + e.LastName);
                });


                //aynı şirkettekileri getirme:

                var employees = db.Employees
                .Where(c => c.Company == "Northwind Traders")
                .ToList();

                employees.ForEach(e => {
                    System.Console.WriteLine(e.FirstName + " " +e.Company);
                });


                //aynı kategorideki ürünlerin belirli özelliklerini getirme:
                var product = db.Products
                .Where(p => p.Category == "Beverages")
                .Select(p => p.ProductName)
                .ToList();

                product.ForEach(p => {
                    System.Console.WriteLine(p);
                });


                //ilk 5 ürünü alma:
                var products = db.Products.Take(5).ToList();

                products.ForEach(p => {
                    System.Console.WriteLine(p.ProductName + "id: "+p.Id);
                });
                

                //son beşi ürünü alma <id ye göre ters sıralayıp ilk 5 ini alıyom>:
                var products = db.Products
                .OrderByDescending(p => p.Id)
                .Take(5)
                .ToList();

                products.ForEach(p => {
                    System.Console.WriteLine(p.Id);
                });


                //belirli fiyattaki ürünleri getiriyorum:
                var products = db.Products
                    .Where(p => p.ListPrice >0 && p.ListPrice <= 30)
                    .Select(p => new {p.ProductName,p.ListPrice})
                    .ToList();

                products.ForEach(p => {
                    System.Console.WriteLine("name: "+p.ProductName + " list price: "+p.ListPrice);
                });


                //ürünlerin fiyatının ortalamasini buluyorum!
                var ortalama = db.Products.Average(p => p.ListPrice );
                System.Console.WriteLine("ortalama: " + ortalama);


                //ürünlerin adetini buluyorum
                var adeti = db.Products.Count();
                System.Console.WriteLine("ürünlerin adeti: " + adeti);


                //belirli ürünlerin adetini bulma:
                var adeti = db.Products.Count(p => p.Category == "Beverages");
                System.Console.WriteLine("adeti: " + adeti);



                //fiyatlarin toplamini bulma:
                var toplamFiyat = db.Products.Sum(p => p.ListPrice);
                System.Console.WriteLine("ürünlerin toplam fiyatı: " + toplamFiyat);


                //belirli categorideki ürünlerin toplam fiyatı:
                var toplamFiyat = db.Products
                    .Where(p => p.Category == "Beverages" || p.Category == "Condiments")
                    .Sum(p => p.ListPrice);

                System.Console.WriteLine("toplam fiyat: " + toplamFiyat);


                //belirli bir kelimeyi içeren ürünleri getirme:
                var products = db.Products
                    .Where(p => p.ProductName.Contains("Tea"))
                    .ToList();
                
                products.ForEach(p => {
                    System.Console.WriteLine(p.ProductName);
                });


                //en pahali urunum fiyatini bulma:
                var enPahaliUrun = db.Products.Max(p => p.ListPrice);
                System.Console.WriteLine(enPahaliUrun);


                //en ucuz ürünün fiyatini bulma:
                var enUcuzUrun = db.Products.Min(p => p.ListPrice);
                System.Console.WriteLine(enUcuzUrun);


                //en pahali urunun kendisini bulma:
                var enPahaliUrununKendisi = db.Products
                    .Where(p => p.ListPrice == ( db.Products.Max(p => p.ListPrice) ))
                    .FirstOrDefault();

                System.Console.WriteLine("ürün adı: "+ enPahaliUrununKendisi.ProductName + " fiyati: "+enPahaliUrununKendisi.ListPrice);


                //en ucuz urunun kendisini bulma
                var enUcuzUrununKendisi = db.Products
                    .Where(p => p.ListPrice == (db.Products.Min(p => p.ListPrice)))
                    .FirstOrDefault();
                
                System.Console.WriteLine("ürün adı: " + enUcuzUrununKendisi.ProductName + " fiyati: " + enUcuzUrununKendisi.ListPrice);


                //iç içe istek atma yani tablonun içindeki id den diğer tablodaki bilgiyi getirme:
                  var customers = db.Customers
                        .Where(c => c.Orders.Count > 0)
                        .Select(c => new {
                            CustomerId = c.Id,
                            Name = c.FirstName,
                            OrderCount = c.Orders.Count(),
                            Orders = c.Orders.Select(co => new {
                                OrderId = co.Id,
                                Total = (decimal)co.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                                Products = co.OrderDetails.Select(p => new {
                                    ProductId = (int)p.ProductId,
                                    Name = p.Product.ProductName
                                })
                                .ToList()
                            
                            }).ToList()
                        })
                        .ToList();

                    //bilgileri ekrana basıyorum
                    customers.ForEach(c => {
                        System.Console.WriteLine($"id: {c.CustomerId} name: {c.Name} count: {c.OrderCount}");
                        c.Orders.ForEach(o => {
                            System.Console.WriteLine($"order id: {o.OrderId} total: {o.Total}"); 
                            o.Products.ForEach(p => {
                                System.Console.WriteLine($"product id: {p.ProductId} Name: {p.Name}");
                            });                            
                        });     
                    });


                     //sql ile sorgu yapma:<daha detaylı isteklerde bulunabiliyorsun bu yapıda sadece * la çağrabiliyorsun detay için kursa bak! kurs adı:(Klasik SQL Sorgularının Entity Framework ile Kullanılması)>
                    var customers = db.Customers.FromSqlRaw("Select * From customers").ToList();

                    customers.ForEach(c => {
                        System.Console.WriteLine("id: "+c.Id+ " company: "+c.FirstName);
                    });




            }



        }
    }
}
