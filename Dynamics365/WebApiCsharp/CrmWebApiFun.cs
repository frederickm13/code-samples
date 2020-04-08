/*
 * Please note, this sample code is provided to the community as-is, and for learning/demonstration purposes only.  
 * This code is not certified for production use without further review and testing by your organization.
*/

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace D365_Projects
{
    public class CrmWebApiFun
    {
        private static readonly AuthenticationContext authContext = new AuthenticationContext("https://login.microsoftonline.com/common");

        private AuthenticationResult authResult;
        private readonly string resource;
        private readonly Uri resourceApi;
        private readonly string clientId;
        private readonly Uri redirectUrl;
        private readonly HttpClient request = new HttpClient();


        // Constructor - Instantiate and set necessary client values for Azure Active Directory
        public CrmWebApiFun(string CrmApiUrl, string AzureAdClientId, string AzureAdRedirectUrl)
        {
            this.resourceApi = new Uri(CrmApiUrl);
            this.clientId = AzureAdClientId;
            this.redirectUrl = new Uri(AzureAdRedirectUrl);

            // Remove API reference from CRM Web API URL to obtain the base resource URL
            this.resource = "https://" + resourceApi.Host + "/";

            // Set request headers if this is the first instance of the object
            request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            request.DefaultRequestHeaders.Add("OData-Version", "4.0");
            request.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            request.BaseAddress = this.resourceApi;
        }

        // Destructor to release the unmanaged HttpClient resource
        ~CrmWebApiFun()
        {
            request.Dispose();
        }

        // Obtain or refresh auth token
        private async Task GetOrRefreshCrmToken()
        {
            if (this.authResult == null || DateTime.UtcNow.AddMinutes(15) >= this.authResult.ExpiresOn)
            {
                this.authResult = await authContext.AcquireTokenAsync(this.resource, this.clientId, this.redirectUrl, new PlatformParameters(PromptBehavior.RefreshSession));
            }

            string authToken = this.authResult.AccessToken;
            request.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        }

        public async Task<HttpResponseMessage> GetCrmData(string queryString)
        {
            await GetOrRefreshCrmToken();

            // Send HTTP GET request, return the HttpResponseMessage
            return await request.GetAsync(queryString);
        }

        public async Task<HttpResponseMessage> PostCrmData(string entityName, string content)
        {
            await GetOrRefreshCrmToken();

            // Create content
            StringContent formattedContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Send HTTP POST request, return the HttpResponseMessage
            return await request.PostAsync(entityName, formattedContent);
        }

        public async Task<HttpResponseMessage> DeleteCrmData(string queryString)
        {
            await GetOrRefreshCrmToken();

            // Send HTTP DELETE request, return the HttpResponseMessage
            return await request.DeleteAsync(queryString);
        }

        public async Task<HttpResponseMessage> PatchCrmData(string queryString, string content)
        {
            await GetOrRefreshCrmToken();

            // Create PATCH request... HttpClient class does not yet support the PatchAsync method in .NET v4.8
            HttpRequestMessage patchRequest = new HttpRequestMessage(new HttpMethod("PATCH"), queryString)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            // Send HTTP PATCH request, dispose of HttpRequestMessage object, return the HttpResponseMessage
            using (patchRequest)
            {
                return await request.SendAsync(patchRequest);
            }
        }
    }
}
