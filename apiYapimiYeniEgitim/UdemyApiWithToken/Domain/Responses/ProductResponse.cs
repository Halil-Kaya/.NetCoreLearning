using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Responses
{
    public class ProductResponse : BaseResponse
    {

        public Product Product { get; set; }

        private ProductResponse(bool success,string message,Product product) : base(success,message){
            this.Product = product;
        }


        public ProductResponse(Product product) : this(true, string.Empty ,product){

        }

        public ProductResponse(string message) : this(false,message,null){
        }

        
    }
}