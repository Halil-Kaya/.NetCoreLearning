using UdemyApiWithToken.Domain.Entities;

namespace UdemyApiWithToken.Domain.Repositories
{
    public class BaseRepository
    {
        
        protected readonly UdemyApiWithTokenDBContext _dbContext;
        
        public BaseRepository(UdemyApiWithTokenDBContext dbContext){
            this._dbContext = dbContext;
        }

    }
}