using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace learning
{

    interface IProductDal{

        List<Product> GetAllProducts();
        Product GetProductByID(int id);
        void Create(Product newProduct);

        void Update(Product product);

        void Delete(int productId);

    }

    class MySQLProductDal : IProductDal
    {

        private MySqlConnection mySqlConnection;

        public MySQLProductDal(){
            this.mySqlConnection = GetMySqlConnection();
        }

        
        private MySqlConnection GetMySqlConnection(){ 
            string connectionString = "server=127.0.0.1;port=3305;username=root;password=;database=northwind";
            return new MySqlConnection(connectionString);
        }

        public int Count(){
            
            int count = 0;

            using(var connection = this.mySqlConnection){

                try{

                    connection.Open();

                    string sqlQuery = "SELECT COUNT(*) FROM products";

                    MySqlCommand command = new MySqlCommand(sqlQuery,connection);

                    count = int.Parse(command.ExecuteScalar().ToString());

                }catch(Exception e){
                    System.Console.WriteLine("hata!: "+e.Message);
                }

            }

            return count;
        }

        public void Create(Product newProduct)
        {
            
            using(var connection = this.mySqlConnection){

                try{

                    connection.Open();

                    string sqlQuery = $"INSERT INTO products (product_name,list_price) VALUES ('{newProduct.Name}',{newProduct.Price})";                
                    MySqlCommand command = new MySqlCommand(sqlQuery,connection);

                    command.ExecuteNonQuery();

                }catch(Exception e){

                    System.Console.WriteLine("hata oldu: "+e);

                }

            }

        }

        public void Delete(int productId)
        {
            
            using(var connection = this.mySqlConnection){

                try{

                    connection.Open();

                    string sqlQuery = $"DELETE FROM products WHERE id = {productId}";

                    MySqlCommand command = new MySqlCommand(sqlQuery,connection);

                    command.ExecuteNonQuery();


                }catch(Exception e){
                    System.Console.WriteLine("hata: "+e.Message);
                }

            }


        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = null;

            using(var connection = this.mySqlConnection){

                try{


                connection.Open();

                string query = "Select * From products";

                MySqlCommand command = new MySqlCommand(query,connection);

                MySqlDataReader reader = command.ExecuteReader();

                products = new List<Product>();

                while(reader.Read()){

                    products.Add(new Product(){
                        ProductId = int.Parse(reader["id"].ToString()),
                        Name = reader["product_name"].ToString(),
                        Price = double.Parse(reader["list_price"].ToString())
                    });
                }

                
                }catch(Exception e){
                    System.Console.WriteLine($"bir hata oldu: {e.Message}");
                }


            }
            

            return products;
        }

        public Product GetProductByID(int id)
        {
            
            Product product = null;

            using(var connection = this.mySqlConnection){

                try{
                    
                    connection.Open();

                    string sqlQuery = $"Select * From products WHERE id = {id}";

                    MySqlCommand command = new MySqlCommand(sqlQuery,connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    product = new Product();
                    
                    reader.Read();

                    if(reader.HasRows){
                        product.ProductId = int.Parse( reader["id"].ToString() );
                        product.Name = reader["product_name"].ToString();
                        product.Price = double.Parse( reader["list_price"].ToString() );
                    }

                    reader.Close();

                }catch(Exception e){
                    System.Console.WriteLine($"bir hata oldu: {e.Message}");
                }


            }
            

            return product;
        }

        public void Update(Product product)
        {
            
            using(var connection = this.mySqlConnection){

                try{

                    connection.Open();

                    string sqlQuery = $"UPDATE products SET product_name = '{product.Name}',list_price = {product.Price} WHERE id ={product.ProductId}";

                    MySqlCommand command = new MySqlCommand(sqlQuery,connection);
                    System.Console.WriteLine(command.ExecuteNonQuery());;

                    
                }catch(Exception e){
                    System.Console.WriteLine("hata oldu: "+e.Message);
                }

            }


        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            
            MySQLProductDal mysqlProductDal = new MySQLProductDal();

            /*
            mysqlProductDal.GetAllProducts().ForEach(p =>{
                System.Console.WriteLine($"ID: {p.ProductId} Name: {p.Name} Price: {p.Price}");
            });
            */

            //mysqlProductDal.GetProductByID(2).printInfo();
            
            
            /*
            mysqlProductDal.Update(new Product(){
                ProductId = 2,
                Name = "Halil Kaya",
                Price = -1
            });*/
            

            mysqlProductDal.Delete(1);

            /*
            mysqlProductDal.Create(new Product(){
                Name = "Halil Kaya",
                Price = 1
            });
            */

            //System.Console.WriteLine(mysqlProductDal.Count());
            
        }




    }
}
