using System.Net.Http.Json;
using BurgerBytes.App.Api.Models;

namespace BurgerBytes.App.Api.HttpClientApi;

public class BurgerBytesHttpClientApi : IBurgerBytesApi
{
    private readonly HttpClient _httpClient;
    private readonly IBurgerBytesHttpClientApiRequestFactory _requestFactory;

    public BurgerBytesHttpClientApi(HttpClient httpClient, IBurgerBytesHttpClientApiRequestFactory requestFactory)
    {
        _httpClient = httpClient;
        _requestFactory = requestFactory;
    }

    public Task<CurrencyDto> GetCurrencyAsync() => SendAsync<CurrencyDto>(HttpMethod.Get, "/v1/ab00c25f-330c-4140-8535-eb0ecdf1dd28");

    private async Task<T> SendAsync<T>(HttpMethod method, string path, IDictionary<string, string>? parameters = null, object? body = null)
    {
        var request = _requestFactory.Create(method, path, parameters, body);

        var response = await _httpClient.SendAsync(request);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Request failed. Path: {path}. Reason Phrase: {response.ReasonPhrase}.", null, response.StatusCode);
        }

        var result = await response.Content.ReadFromJsonAsync<T>();
        
        if (result is null)
        {
            throw new NullReferenceException($"API response wasn't expected to be null. Path: {path}");
        }
        
        return result;
    }
}