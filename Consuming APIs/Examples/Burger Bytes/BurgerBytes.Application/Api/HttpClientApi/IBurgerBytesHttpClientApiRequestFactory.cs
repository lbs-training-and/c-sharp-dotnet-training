namespace BurgerBytes.App.Api.HttpClientApi;

public interface IBurgerBytesHttpClientApiRequestFactory
{
    HttpRequestMessage Create(HttpMethod method, string path, IDictionary<string, string>? parameters = null, object? body = null);
}