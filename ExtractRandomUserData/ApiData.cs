namespace ExtractRandomUserData
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ApiData
    {
        [JsonProperty]
        public ICollection<Result> Results { get; set; }
    }
}
