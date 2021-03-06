# MetabaseEmbedding
A library help to create metabase embedding url

## Install

```
dotnet add package MetabaseEmbedding --version 1.0.2
```

## Usage

### Configuration

```
{
  "Metabase": {
    "SiteUrl": "http://localhost:4000",
    "SecretKey": "6f55122d4843147b9c6573e7358657bceb4bdd7f6478311f6ba7787702876866"
  }
}
```

### Add service

```
  serviceCollection.AddMetabaseEmbedding(configuration);
  
  var generator = serviceProvider.GetRequiredService<IIFrameUrlGenerator>();
  var url = generator.Create(ResourceType.Dashboard, 9, new Dictionary<string, object>
  {
    { "type", "xxx" }
  }, 10, new Dictionary<string, string>
  {
    { "bordered", "false" },
    { "titled", "false" }
  });
```

## License

This repository is licensed with the [MIT](LICENSE.txt) license.

## Buy me a coffee

![](https://github.com/zlzforever/ClickHouseMigrator/raw/master/images/alipay.jpeg)
