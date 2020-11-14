using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWorks
    {  
        IProductRepository Products { get;}
        
        ICategoryRepository Categories { get;}

        Task CommitAsync();

        void Commit();
        
    }
}