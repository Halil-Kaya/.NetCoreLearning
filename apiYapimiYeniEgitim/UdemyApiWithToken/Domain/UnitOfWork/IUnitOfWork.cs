using System.Threading.Tasks;

namespace UdemyApiWithToken.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {

        Task CompleteAsync();

        void Complete();
    }
}