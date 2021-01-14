using IbgeService.Builders;
using IbgeService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IbgeService.Services
{
    public class IbgeService : IIbgeService
    {
        private readonly HttpClient _client;
        private readonly ILogger<IbgeService> _logger;

        public IbgeService(HttpClient client, ILogger<IbgeService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<FrequenciaNomeModel> GetFrequenciaNomeAsync(string nome, QueryParameters queryParameters = null)
        {
            try
            {
                FrequenciaNomeModel frequenciaNome;

                _logger.LogInformation("Enviando solicitação ({0}) para obter listagem com frequência de nascimentos por década do nome {1}", _client.BaseAddress, nome);

                if (!(queryParameters.Sexo is null && queryParameters.Localidade is null))
                {
                    var query = new QueryParametersBuilder()
                        .AddSexo(queryParameters.Sexo)
                        .AddLocalidade(queryParameters.Localidade)
                        .Build();

                    frequenciaNome = await _client
                        .GetFromJsonAsync<FrequenciaNomeModel>($"censos/nomes/{nome}{query}");

                    _logger.LogInformation("Solicitação processada com êxito.");
                    return frequenciaNome;
                }

                frequenciaNome = await _client
                    .GetFromJsonAsync<FrequenciaNomeModel>($"censos/nomes/{nome}");

                _logger.LogInformation("Solicitação processada com êxito.");
                return frequenciaNome;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _client.Dispose();
            }
        }

        public async Task<IReadOnlyList<NomeModel>> GetFrequenciaNomesAsync()
        {
            try
            {
                _logger.LogInformation("Enviando solicitação ({0}) para obter listagem com frequência de nascimentos por década", _client.BaseAddress);

                var frequenciaNomes = await _client
                    .GetFromJsonAsync<IReadOnlyList<NomeModel>>("censos/nomes");

                _logger.LogInformation("Solicitação processada com êxito. Retornando lista com {0} objetos.", frequenciaNomes.Count);

                return frequenciaNomes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _client.Dispose();
            }
        }

        public async Task<IReadOnlyList<FrequenciaNomeModel>> GetFrequenciaNomesAsync(params string[] nomes)
        {
            try
            {
                _logger.LogInformation("Enviando solicitação ({0}) para obter listagem com frequência de nascimentos por década dos nomes {0}", _client.BaseAddress, string.Join(",", nomes));

                var frequenciaNomes = await _client
                    .GetFromJsonAsync<IReadOnlyList<FrequenciaNomeModel>>($"censos/nomes/{string.Join("|", nomes)}");

                _logger.LogInformation("Solicitação processada com êxito. Retornando lista com {0} objetos.", frequenciaNomes.Count);

                return frequenciaNomes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _client.Dispose();
            }
        }

        public async Task<RankingNomeModel> GetRankingNomeAsync(QueryParameters queryParameters = null)
        {
            try
            {
                RankingNomeModel rankingNome;

                _logger.LogInformation("Enviando solicitação ({0}) para obter listagem com ranking de nascimentos por década", _client.BaseAddress);

                if (!(queryParameters.Sexo is null 
                    && queryParameters.Localidade is null 
                    && queryParameters.Decada is null))
                {
                    var query = new QueryParametersBuilder()
                        .AddSexo(queryParameters.Sexo)
                        .AddLocalidade(queryParameters.Localidade)
                        .AddDecada(queryParameters.Decada)
                        .Build();

                    rankingNome = await _client
                        .GetFromJsonAsync<RankingNomeModel>($"censos/nomes/ranking{query}");

                    _logger.LogInformation("Solicitação processada com êxito.");
                    return rankingNome;
                }

                rankingNome = await _client
                    .GetFromJsonAsync<RankingNomeModel>($"censos/nomes/ranking");

                _logger.LogInformation("Solicitação processada com êxito.");
                return rankingNome;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _client.Dispose();
            }
        }
    }
}
