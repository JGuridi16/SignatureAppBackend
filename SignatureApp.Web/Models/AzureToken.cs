﻿using Newtonsoft.Json;

namespace SignatureApp.Web.Models
{
    public class AzureToken
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; } = string.Empty;

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        
        [JsonProperty("ext_expires_in")]
        public int ExtExpiresIn { get; set; }
        
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = string.Empty;
    }
}
