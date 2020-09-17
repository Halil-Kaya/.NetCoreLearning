using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository){
            this._productRepository = productRepository;
        }


       public bool Create(Product entity)
        {
            if(Validation(entity)){
                _productRepository.Create(entity);
                return true;
            }else{
                return false;
            }
        }

        public void Delete(Product entitiy)
        {
            _productRepository.Delete(entitiy);
        }

        public List<Product> GetAll()
        {   
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {   
            return _productRepository.GetCountByCategory(category);
        } 

        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name,int page,int pageSize)
        {
            return _productRepository.GetProductsByCategory(name,page,pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        public void Update(Product entity, int[] CategoryIds)
        {
            _productRepository.Update(entity,CategoryIds);
        }
        public string ErrorMessage { get ; set ; }

        public bool Validation(Product entity)
        {
           
            var isValid = true;
            
            if(string.IsNullOrEmpty(entity.Name)){
                ErrorMessage += "ürün ismi girmelisiniz.\n";
                isValid = false;
            }

            if(entity.Price < 0){
                ErrorMessage += "ürün fiyati negatif olamaz.\n";
                isValid = false;
            }

            return isValid;
       
        }

        
    }
}