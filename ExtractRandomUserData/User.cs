namespace ExtractRandomUserData
{
    using Newtonsoft.Json;

    public class User
    {
        [JsonProperty]
        public Name Name { get; set; }

        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public string Username { get; set; }
    }
}
