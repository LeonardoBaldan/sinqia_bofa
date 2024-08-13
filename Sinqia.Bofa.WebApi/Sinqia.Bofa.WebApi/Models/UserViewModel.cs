using System.Text.Json.Serialization;

namespace Sinqia.Bofa.WebApi.Models
{
    public class UserViewModel
    {
        #region properties

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        #endregion
    }
}
