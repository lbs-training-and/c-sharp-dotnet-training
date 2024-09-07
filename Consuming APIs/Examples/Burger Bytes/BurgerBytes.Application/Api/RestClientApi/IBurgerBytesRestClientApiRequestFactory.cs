using RestSharp;

namespace BurgerBytes.App.Api.RestClientApi;

public interface IBurgerBytesRestClientApiRequestFactory
{
    RestRequest Create(Method method, string path, IDictionary<string, string>? parameters = null, object? body = null);
}