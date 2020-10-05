using System.Threading.Tasks;
using UdemyApiWithToken.Domain.Entities;

namespace UdemyApiWithToken.Domain.UnitOfWork 
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly UdemyApiWithTokenDBContext _dbcontext;

        public UnitOfWork(UdemyApiWithTokenDBContext dBContext){
            this._dbcontext = dBContext;
        }


        public async Task CompleteAsync()
        {

            await this._dbcontext.SaveChangesAsync();

        }
    }
}