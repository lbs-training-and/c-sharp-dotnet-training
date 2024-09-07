using RestSharp;

namespace BurgerBytes.App.Api;

public interface IBurgerBytesApiRequestFactory
{
    RestRequest Create(Method method, string path, IDictionary<string, string>? parameters = null, object? body = null);
}