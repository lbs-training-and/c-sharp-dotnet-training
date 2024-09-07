using BurgerBytes.App.Api.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace BurgerBytes.App.Api.RestClientApi;

public class BurgerBytesRestClientApiRequestFactory : IBurgerBytesRestClientApiRequestFactory
{
    private readonly IOptions<BurgerBytesApiSettings> _options;

    public BurgerBytesRestClientApiRequestFactory(IOptions<BurgerBytesApiSettings> options)
    {
        _options = options;
    }
    
    public RestRequest Create(Method method, string path, IDictionary<string, string>? parameters = null, object? body = null)
    {
        var uri = new UriBuilder(_options.Value.BaseUrl)
        {
            Path = path
        }.Uri;
        
        var request = new RestRequest(uri, method);

        if (body is not null)
        {
            request.AddJsonBody(request);
        }

        foreach (var p in parameters ?? new Dictionary<string, string>())
        {
            request.AddQueryParameter(p.Key, p.Value);
        }

        return request;
    }
}