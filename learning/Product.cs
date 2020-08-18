namespace learning
{
    public class Product
    {
        
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void printInfo(){

            
            System.Console.WriteLine($"ID: {this.ProductId} Name: {this.Name} Price: {this.Price}");


        }

    }
}