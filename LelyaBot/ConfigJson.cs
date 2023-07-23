using Newtonsoft.Json;

namespace LelyaBot;

internal struct ConfigJson
{   
    [JsonProperty("token")] public string Token { get; private set; }
    [JsonProperty("prefix")] public string Prefix { get; private set; }
}