using Newtonsoft.Json;
using SignatureApp.Web.Models;
using SignatureApp.Web.Models.GraphAPI;
using System.Net.Http.Headers;
using System.Text;

namespace SignatureApp.Web.Services
{
    public interface ISignatureService
    {
        Task<bool> SaveSignatureDataIntoSharePoint(SignatureDto dto);
    }
    public class SignatureService : ISignatureService
    {
        private readonly HttpClient _client;
        private readonly AppSettings _appSettings;
        private readonly AzureSettings _azureSettings;

        public ILogger<SignatureService> _logger { get; }

        public SignatureService(IHttpClientFactory clientFactory, ILogger<SignatureService> logger, AppSettings appSettings, AzureSettings azureSettings)
        {
            _client = clientFactory.CreateClient();
            _appSettings = appSettings;
            _azureSettings = azureSettings;
            _logger = logger;
        }
        private async Task<AzureToken?> SetAccessToken()
        {
            var tenantId = _azureSettings.TenantId;
            var loginUrl = _azureSettings.TokenEndpoint?.Replace("{{TenantId}}", tenantId);

            var dict = new Dictionary<string, string>();
            dict.Add("grant_type", _azureSettings.GrantType);
            dict.Add("client_id", _azureSettings.ClientId);
            dict.Add("client_secret", _azureSettings.ClientSecret);
            dict.Add("scope", _azureSettings.Scope);

            var response = await _client.PostAsync(loginUrl, new FormUrlEncodedContent(dict));
            var json = await response.Content.ReadAsStringAsync();

            var contentResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) _logger.LogError(contentResponse);

            var token = JsonConvert.DeserializeObject<AzureToken>(json);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token?.AccessToken);

            return token;
        }

        private async Task<string> GetSharePointProfileSiteId()
        {
            var tenantName = _azureSettings.TenantName;
            var siteName = _azureSettings.SiteName;
            var siteProfileUrl = _appSettings.SiteProfileEndpoint?
                .Replace("{{TenantName}}", tenantName)
                .Replace("{{SiteName}}", siteName);

            var response = await _client.GetAsync(siteProfileUrl);

            var contentResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) _logger.LogError(contentResponse);

            var json = await response.Content.ReadAsStringAsync();

            var profile = JsonConvert.DeserializeObject<SiteProfile>(json);

            return profile?.Id ?? string.Empty;
        }

        private async Task<string> GetSharePointSiteListId(string siteId)
        {
            var siteListsUrl = _appSettings.SiteListsEndpoint?
                .Replace("{{SiteId}}", siteId);

            var response = await _client.GetAsync(siteListsUrl);
            var json = await response.Content.ReadAsStringAsync();

            var contentResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) _logger.LogError(contentResponse);

            var siteLists = JsonConvert.DeserializeObject<SiteListRoot>(json);

            var listItem = siteLists?.Value.Where(x => x.DisplayName == _azureSettings.ListName).FirstOrDefault();

            return listItem?.Id ?? string.Empty;
        }

        private async Task<bool> InsertSharePointListItem(string siteId, string listId, SignatureDto dto)
        {
            var insertItemUrl = _appSettings.SiteInsertItemEndpoint?
                .Replace("{{SiteId}}", siteId)
                .Replace("{{ListId}}", listId);

            var payload = JsonConvert.SerializeObject(new SignatureRoot
            {
                Fields = dto
            });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(insertItemUrl, content);

            var contentResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) _logger.LogError(contentResponse);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SaveSignatureDataIntoSharePoint(SignatureDto dto)
        {
            await SetAccessToken();

            var siteId = await GetSharePointProfileSiteId();

            var listId = await GetSharePointSiteListId(siteId);

            return await InsertSharePointListItem(siteId, listId, dto);
        }
    }
}
