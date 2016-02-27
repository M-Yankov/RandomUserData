namespace ExtractRandomUserData
{
    using Newtonsoft.Json;

    public class Name
    {
        [JsonProperty]
        public string First { get; set; }

        [JsonProperty]
        public string Last { get; set; }
    }
}
