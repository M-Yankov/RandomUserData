namespace ExtractRandomUserData
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

    using Newtonsoft.Json;

    public class Program
    {
        public static void Main()
        {
            WebClient client = new WebClient();
            string randomData = client.DownloadString("http://api.randomuser.me/?results=2000");

            ApiData data = JsonConvert.DeserializeObject<ApiData>(randomData);

            IEnumerable<string> firstNames = data.Results.Select(c => c.User.Name.First);
            IEnumerable<string> lastNames = data.Results.Select(c => c.User.Name.Last);
            IEnumerable<string> emails = data.Results.Select(c => c.User.Email.Replace(" ", string.Empty));
            IEnumerable<string> usernames = data.Results.Select(c => c.User.Username);

            IDictionary<string, IEnumerable<string>> datas = new Dictionary<string, IEnumerable<string>>()
            {
                { "..\\..\\FNames.txt", firstNames },
                { "..\\..\\LNames.txt",  lastNames },
                { "..\\..\\Emails.txt", emails },
                { "..\\..\\Usernames.txt", usernames }
            };

            foreach (var collection in datas)
            {
                WriteToFile(collection.Key, collection.Value);
            }
        }

        private static void WriteToFile<T>(string path, IEnumerable<T> data) where T : class
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (var item in data)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
