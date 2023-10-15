using Newtonsoft.Json;

namespace Bot;

internal struct Config
{
    public Config(string token, string prefix)
    {
        Token = token;
        Prefix = prefix;
    }

    [JsonProperty("token")] public string Token { get; private set; }
    [JsonProperty("prefix")] public string Prefix { get; private set; }
}