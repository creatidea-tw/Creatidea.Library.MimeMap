# MimeTypeMap.List

[![Build Status](https://dev.azure.com/lettucebo/Github.Build/_apis/build/status/MimeTypeMap.List.Build?branchName=master)](https://dev.azure.com/lettucebo/Github.Build/_build/latest?definitionId=21&branchName=master)

简体中文：[README.CN.md](https://github.com/lettucebo/MimeTypeMap.List/blob/master/README.CN.md)
<br/>
正體中文：[README.TW.md](https://github.com/lettucebo/MimeTypeMap.List/blob/master/README.TW.md)

## Summary
Provides a huge two-way mapping of file extensions to mime types and mime types to file extensions, e.g.:

```c#
...
{".jpe", "image/jpeg"},
{".jpeg", "image/jpeg"},
{".jpg", "image/jpeg"},
{".js", "application/javascript"},
{".json", "application/json"},
...
```
---

## Note

There is a little different behavior between [samuelneff](https://github.com/samuelneff/MimeTypeMap) version. 

In my experience, one extension sometimes will have different mime type depend on various browser. 

**This package will return all match mime.**

For example: `.mp3` and `zip` will have multi mime type depend on various browser, see: https://stackoverflow.com/a/28021591/1799047
, `.zip` will have three mime type: `application/zip, application/octet-stream, application/x-zip-compressed`

## Installation

A NuGet package is available for easy integration into VisualStudio and automatic updates. Alternatively, you can clone and reference or copy the class to your project.

```bash
Install-Package MimeTypeMap.List
```

## Support Platform

Support .NET 4.6.1 above or .NET Standard 2.0 above

## Usage

After installation MimeTypeMap, include the following using statement in your class:

```cs
using MimeTypeMap.List;
```

### Getting the mime type to an extension

```cs
Console.WriteLine("txt -> " + MimeTypeMap.GetMimeType("txt"));  // "text/plain"
```

Pass in a string extension and get a mime type back. Optionally include the period. If not it will be added before looking up the mime type.

If no mime type is found then the generic "application/octet-stream" is returned.

### Getting the extension to a mime type

```cs
Console.WriteLine("audio/wav -> " + MimeTypeMap.GetExtension("audio/wav")); // ".wav, .wave"
```

Pass in a mime type and get an extension back. If the mime type is not registered, an error is thrown.

### Example

see the example project and try for yourself


## Collaboration

Please submit pull requests for any additions. Thanks!
