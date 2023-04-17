using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceNowComparerLibrary.Storage.Models;

namespace ServiceNowComparerLibrary.Modules.Instance
{
    public class ServiceNowInstanceHelper
    {
        private ServiceNowInstance _serviceNowInstance;
        private bool _authenticatedOnInstance;
        private string? _base64AuthInfo;
        private HttpClient _client;

        public ServiceNowInstanceHelper(ServiceNowInstance serviceNowInstance)
        {
            _serviceNowInstance = serviceNowInstance;
            _base64AuthInfo = GenerateAuthInfo();
            _authenticatedOnInstance = false;
            _client = new HttpClient();
        }

        public string PrepareClientUriWithWrapper(ServiceNowApiWrapper serviceNowApiWrapper)
        {
            if (_base64AuthInfo == null) throw new Exception("Missing Authenticationobject -> _base64AuthInfo");

            serviceNowApiWrapper.Header.Add("Authorization", $"Basic {_base64AuthInfo}");
            serviceNowApiWrapper.Header.Add("Accept", "application/xml");

            foreach (KeyValuePair<string, string> item in serviceNowApiWrapper.Header)
            {
                _client.DefaultRequestHeaders.Add(item.Key, item.Value);
            }

            StringBuilder RequestUri = new StringBuilder();

            RequestUri.Append(_serviceNowInstance.Url);
            if (serviceNowApiWrapper.ApiVersion != "latest")
            {
                RequestUri.Append($"/api/now/{serviceNowApiWrapper.ApiVersion}");
            }
            else
            {
                RequestUri.Append($"/api/now");
            }
            RequestUri.Append($"/table/{serviceNowApiWrapper.Table}");
            RequestUri.Append($"?sysparm_limit={serviceNowApiWrapper.limit}");

            return RequestUri.ToString();
        }

        private string? GenerateAuthInfo()
        {
            if (_serviceNowInstance.User == null) throw new ArgumentNullException("ServiceNow Instance dosent provide a user");
            string? Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_serviceNowInstance.User.Label}:{_serviceNowInstance.User.Password}"));
            return Auth;
        }
    }

    public class ServiceNowApiWrapper
    {
        public string ApiVersion { get; set; }
        public string? Table { get; set; }
        public HttpMethod? ApiAction { get; set; }
        public string? EncodedQuery { get; set; }
        public string? ReturnFields { get; set; }
        public int limit { get; set; }
        public Dictionary<String, String> Header { get; set; }

        public ServiceNowApiWrapper()
        {
            ApiVersion = "latest";
            limit = 1;
        }
    }
}