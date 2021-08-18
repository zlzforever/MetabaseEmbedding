using System;
using System.Collections.Generic;
using System.Linq;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.Extensions.Options;

namespace MetabaseEmbedding
{
    // ReSharper disable once InconsistentNaming
    public class IFrameUrlGenerator : IIFrameUrlGenerator
    {
        private readonly MetabaseOptions _options;
        private static readonly IJsonSerializer Serializer = new JsonNetSerializer();
        private static readonly IBase64UrlEncoder UrlEncoder = new JwtBase64UrlEncoder();
        private static readonly Dictionary<string, object> EmptyObject = new();

        public IFrameUrlGenerator(IOptionsMonitor<MetabaseOptions> options)
        {
            _options = options.CurrentValue;
        }

        public string Create(Resource resource, int exp = 10,
            Dictionary<string, object> parameters = null, Dictionary<string, object> displayOptions = null)
        {
            var payload = new Dictionary<string, object>
            {
                {
                    "resource",
                    new Dictionary<string, object>
                    {
                        { resource.Type.ToString().ToLowerInvariant(), resource.Id }
                    }
                },
                { "params", parameters ?? EmptyObject },
                { "exp", DateTimeOffset.Now.ToUnixTimeSeconds() + exp * 60 } // 10 minute expiration
            };

            // 1629282669
            var algorithm = new HMACSHA256Algorithm(); // symmetric
            var encoder = new JwtEncoder(algorithm, Serializer, UrlEncoder);
            var token = encoder.Encode(payload, _options.SecretKey);

            var displayOptionsUrl = displayOptions == null
                ? string.Empty
                : string.Join("&", displayOptions.Select(x => $"{x.Key}={x.Value}"));
            return
                $"{_options.SiteUrl}/embed/{resource.Type.ToString().ToLowerInvariant()}/{token}#{displayOptionsUrl}";
        }
    }
}