using BurgerBytes.App.Api.Models;
using RestSharp;

namespace BurgerBytes.App.Api;

public class BurgerBytesApi : IBurgerBytesApi
{
    private readonly IRestClient _restClient;
    private readonly IBurgerBytesApiRequestFactory _requestFactory;

    public BurgerBytesApi(IRestClient restClient, IBurgerBytesApiRequestFactory requestFactory)
    {
        _restClient = restClient;
        _requestFactory = requestFactory;
    }

    public Task<CurrencyDto> GetCurrencyAsync() => SendAsync<CurrencyDto>(Method.Get, "/v1/ab00c25f-330c-4140-8535-eb0ecdf1dd28");

    private async Task<T> SendAsync<T>(Method method, string path, IDictionary<string, string>? parameters = null, object? body = null)
    {
        var request = _requestFactory.Create(method, path, parameters, body);

        var result = await _restClient.GetAsync<T>(request);

        if (result is null)
        {
            throw new NullReferenceException($"API response wasn't expected to be null. Path: {path}");
        }

        return result;
    }
}