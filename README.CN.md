# MimeTypeMap

## 简介

提供广大双向的映射以让扩展文件转换至mime以及让mime转换至扩展文件，范例：

```
...
{".jpe", "image/jpeg"},
{".jpeg", "image/jpeg"},
{".jpg", "image/jpeg"},
{".js", "application/javascript"},
{".json", "application/json"},
...
```

## 备注

此版本与 [samuelneff](https://github.com/samuelneff/MimeTypeMap) 版本有些微的不同

在实际的经验中，透过不同的浏览器上传同样的档案，会产生不同的 mime，所以此套件将会回传此副档名所有符合的 mime

举例来说：`.mp3` 和 `zip` 根据不同的浏览器都有不同的 mime, 参考: <https://stackoverflow.com/a/28021591/1799047> ；`.zip` 共有三种不同的 mime: `application/zip, application/octet-stream, application/x-zip-compressed`

## 贡献

非常欢迎大家尽量提交 PR

## 安装

在 NuGet 有提供套件可以安装，或者是也可以自己把专案复制下来建置 dll.

```bash
Install-Package MimeTypeMap.List
```

## 支援平台

支援 .NET 4.5 以上与 .NET Core 1.0 以上

## 用法

安装MimeTypeMap之后， 包括以下指令在您的class之中：

```csharp
using MimeTypeMap.List;
```

### 根据副档名取得 mime

```csharp
Console.WriteLine("txt -> " + MimeTypeMap.GetMimeType("txt"));  // "text/plain"
```

如果没有 mime 符合的话，预设会回传 "application/octet-stream" 。

### 根据 mime 取得向对应的副档名

```csharp
Console.WriteLine("audio/wav -> " + MimeTypeMap.GetExtension("audio/wav")); // ".wav"
```