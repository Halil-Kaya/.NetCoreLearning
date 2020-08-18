using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace c__Learning
{
    class Program
    {
        
        static void Main(string[] args)
        {

            List<Product> products = GetAllProducts();

            products.ForEach(value =>{
               System.Console.WriteLine($"id: {value.ProductId} Name: {value.Name} Price: {value.Price}"); 
            });

        }

        
        public static List<Product> GetAllProducts(){

            List<Product> products = null;
            
            using(var connection = GetMySqlConnection()){
                try{
                    
                    connection.Open();

                    string sqlQuery = "Select * From products";
                    
                    MySqlCommand command = new MySqlCommand(sqlQuery,connection);
                    
                    MySqlDataReader reader = command.ExecuteReader();
                    
                    products = new List<Product>();
                    
                    while(reader.Read()){
                        products.Add(new Product(){
                            ProductId = int.Parse(reader["id"].ToString()),
                            Name = reader["product_name"].ToString(),
                            Price = double.Parse(reader["list_price"].ToString())
                        });
                    }
                    reader.Close();
                }catch(Exception e){
                    System.Console.WriteLine("bağlantıda sorun yaşandı");
                    System.Console.WriteLine(e.Message);
                }
            }

            return products;
            

        }

        public static MySqlConnection GetMySqlConnection(){

            string connectionString = "server=127.0.0.1;port=3305;username=root;password=;database=northwind";
            return new MySqlConnection(connectionString);
        }

    }
}
