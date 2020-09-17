using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService : IValidator<Category>
    {
         
         Category GetById(int id);

        Category GetByIdWithProducts(int categoryId);
         List<Category> GetAll();

         void Create(Category entity);

         void Update(Category entity);

         void Delete(Category entitiy);
         void DeleteFromCategory(int productId,int categoryId);
    }
}