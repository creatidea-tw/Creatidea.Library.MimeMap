# Changelog

## ## [v2.0.0](https://github.com/lettucebo/MimeTypeMap.List/tree/v2.0.0) (2018-11-05)
[Full Changelog](https://github.com/lettucebo/MimeTypeMap.List/compare/v1.1.0...v2.0.0)

**Implemented enhancements:**

- Refactor to netstandard1.0 for .NET Core support

**Breaking changes**

- Replace `MimeTypeMap.GetExtension` functionality by `MimeTypeMap.GetKnownExtensions`, see example: [MimeTypeMap.List.Example.NetCore](https://github.com/lettucebo/MimeTypeMap.List/tree/master/MimeTypeMap.List.Example.NetCore)
  **No more predefine of mime to extension, just reverse tracing the MappingList.**

- Remove `MimeTypeMap.GetKnownExtensions`

