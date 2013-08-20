using Core.Models.Interface;

namespace Core.Models.Repository
{
    public class CategoryRepository:BaseRepository<int,Category>,ICategoryRepository<int>
    {
        public CategoryRepository(string userName):base(userName)
        {

        }
    }
}
