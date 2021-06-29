using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IGuildService : IBaseService<Guild>
    {
        Task<IEnumerable<Guild>> GetGuildsByRegionId(long regionId);
    }
}
