using IbgeService.Models;

namespace IbgeService.Builders
{
    public class QueryParametersBuilder
    {
        private readonly QueryParameters _queryParameters;

        public QueryParametersBuilder() => _queryParameters = new QueryParameters();

        public QueryParametersBuilder AddSexo(string sexo)
        {
            _queryParameters.Sexo = sexo;
            return this;
        }

        public QueryParametersBuilder AddLocalidade(string localidade)
        {
            _queryParameters.Localidade = localidade;
            return this;
        }

        public QueryParametersBuilder AddDecada(string decada)
        {
            _queryParameters.Decada = decada;
            return this;
        }

        public string Build()
        {
            var query = string.Empty;

            if (!string.IsNullOrEmpty(_queryParameters.Sexo)
                && !string.IsNullOrEmpty(_queryParameters.Localidade))
            {
                query = $"?sexo={_queryParameters.Sexo}&localidade={_queryParameters.Localidade}";
            }
            else if (!string.IsNullOrEmpty(_queryParameters.Sexo)
                && string.IsNullOrEmpty(_queryParameters.Localidade))
            {
                query = $"?sexo={_queryParameters.Sexo}";
            }
            else if (!string.IsNullOrEmpty(_queryParameters.Localidade)
                && string.IsNullOrEmpty(_queryParameters.Sexo))
            {
                query = $"?localidade={_queryParameters.Localidade}";
            }

            return query;
        }
    }
}
