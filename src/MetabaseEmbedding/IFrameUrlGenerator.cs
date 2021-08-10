using System;
using System.Collections.Generic;
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

        public IFrameUrlGenerator(IOptionsMonitor<MetabaseOptions> options)
        {
            _options = options.CurrentValue;
        }

        public string Create(int question, int exp)
        {
            var payload = new Dictionary<string, object>()
            {
                { "resource", new { question = 1 } },
                { "params", new Dictionary<string, object>() },
                { "exp", DateTimeOffset.Now.UtcTicks / 1000 + 10 * 60 },
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, _options.SecretKey);
            return $"{_options.SiteUrl}/embed/question/{token}#bordered=true&titled=true";
        }
    }
}