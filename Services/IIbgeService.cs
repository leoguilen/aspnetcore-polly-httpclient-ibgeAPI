using IbgeService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IbgeService.Services
{
    public interface IIbgeService
    {
        Task<IReadOnlyList<NomeModel>> GetFrequenciaNomesAsync();
        Task<IReadOnlyList<FrequenciaNomeModel>> GetFrequenciaNomesAsync(params string[] nomes);
        Task<FrequenciaNomeModel> GetFrequenciaNomeAsync(string nome, QueryParameters queryParameters = null);
        Task<RankingNomeModel> GetRankingNomeAsync(QueryParameters queryParameters = null);
    }
}
