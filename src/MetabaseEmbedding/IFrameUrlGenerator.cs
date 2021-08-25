using System;
using System.Collections.Generic;
using System.Linq;
using JWT;
using JWT.Algorithms;
using Microsoft.Extensions.Options;

namespace MetabaseEmbedding
{
    // ReSharper disable once InconsistentNaming
    public class IFrameUrlGenerator : IIFrameUrlGenerator
    {
        private readonly MetabaseOptions _options;
        private static readonly IBase64UrlEncoder UrlEncoder = new JwtBase64UrlEncoder();

        public IFrameUrlGenerator(IOptionsMonitor<MetabaseOptions> options)
        {
            _options = options.CurrentValue;
        }

        public string Create(ResourceType type, int id, Dictionary<string, object> parameters = null, int exp = 10,
            Dictionary<string, string> displayOptions = null)
        {
            var payload = Payload.Create(type, id, parameters, DateTimeOffset.Now.ToUnixTimeSeconds() + exp * 60);
            var algorithm = new HMACSHA256Algorithm(); // symmetric
            var encoder = new JwtEncoder(algorithm, JsonSerializer.Instance, UrlEncoder);
            var token = encoder.Encode(payload, _options.SecretKey);

            var displayOptionsUrl = displayOptions == null
                ? string.Empty
                : string.Join("&", displayOptions.Select(x => $"{x.Key}={x.Value}"));
            return
                $"{_options.SiteUrl}/embed/{type}/{token}#{displayOptionsUrl}";
        }
    }
}