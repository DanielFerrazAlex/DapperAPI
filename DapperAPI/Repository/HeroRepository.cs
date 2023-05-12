using DapperAPI.Data;
using DapperAPI.Models;

namespace DapperAPI.Repository
{
    public class HeroRepository : RepositoryBase, IHeroRepository
    {
        public HeroRepository(HeroContext context) : base(context)
        {
        }
    }
}
