namespace ExtractRandomUserData
{
    using Newtonsoft.Json;

    public class Result
    {
        [JsonProperty]
        public User User { get; set; }
    }
}
