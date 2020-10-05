using System.Collections.Generic;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Responses
{
    public class ProductListResponse : BaseResponse
    {
        

        public IEnumerable<Product> ProductList { get; set; }

        private ProductListResponse(bool success,string message,IEnumerable<Product> productList) : base(success,message){
            this.ProductList = productList;
        }


        public ProductListResponse(IEnumerable<Product> ProductList) : this(true, string.Empty ,ProductList){

        }

        public ProductListResponse(string message) : this(false,message,null){
        }


    }
}