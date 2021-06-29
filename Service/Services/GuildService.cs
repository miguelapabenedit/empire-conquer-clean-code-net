using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GuildService : BaseService<Guild>, IGuildService
    {
        public GuildService(IUnitOfWork unitOfWork, IRepository<Guild> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<Guild>> GetGuildsByRegionId(long regionId)
        {
            return await _repository.GetAsync(g => g.RegionGuilds.Any(uo => uo.RegionId.Equals(regionId))).ConfigureAwait(false);
        }
    }
}
 