using System.Net.Http.Json;
using BurgerBytes.App.Api.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace BurgerBytes.App.Api.HttpClientApi;

public class BurgerBytesHttpClientApiRequestFactory : IBurgerBytesHttpClientApiRequestFactory
{
    private readonly IOptions<BurgerBytesApiSettings> _options;

    public BurgerBytesHttpClientApiRequestFactory(IOptions<BurgerBytesApiSettings> options)
    {
        _options = options;
    }


    public HttpRequestMessage Create(HttpMethod method, string path, IDictionary<string, string>? parameters = null, object? body = null)
    {
        var uriBuilder = new UriBuilder(_options.Value.BaseUrl)
        {
            Path = path,
        };

        if (parameters is { Count: > 0 })
        {
            uriBuilder.Query = parameters.Aggregate("?", (s, pair) => $"{s}{pair.Key}={pair.Value}&").TrimEnd('&');
        }

        var request = new HttpRequestMessage(method, uriBuilder.Uri);

        if (body is not null)
        {
            request.Content = JsonContent.Create(body);
        }

        return request;
    }
}