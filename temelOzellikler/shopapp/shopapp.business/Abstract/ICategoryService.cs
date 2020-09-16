using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService
    {
         
         Category GetById(int id);

         List<Category> GetAll();

         void Create(Category entity);

         void Update(Category entity);

         void Delete(Category entitiy);
    }
}