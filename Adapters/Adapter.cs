using Newtonsoft.Json.Linq;

namespace JsonIsNotJustAnyJson.Adapters
{
    internal class Adapter
    {
        public Adapter() { }

        public async Task<JObject> Receive()
        {
            string jsonString = @"
                {
                    ""current"": {
                        ""weather"": [
                            {
                                ""description"": ""Clear sky"",
                                ""temperature"": ""15"",
                                ""pressure"": ""1012""
                            }
                        ]
                    }
                }";

            return await Task.FromResult(JObject.Parse(jsonString));
        }
    }
}
