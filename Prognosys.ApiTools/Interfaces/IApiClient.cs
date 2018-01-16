using System;

namespace Prognosys.ApiTools.Interfaces
{
    public interface IApiClient : IDisposable
    {
        T Get<T>(string requestUri);
        T Post<T>(string requestUri, object content);
        void Post(string requestUri, object content);
        T Put<T>(string requestUri, object content);
        void Put(string requestUri, object content);
        void Delete(string requestUri);
    }
}
