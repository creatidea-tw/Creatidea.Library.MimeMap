# MimeTypeMap

## 簡介

提供廣大雙向的映射以讓擴展文件轉換至mime以及讓mime轉換至擴展文件，列子：

    ...
    {".jpe", "image/jpeg"},
    {".jpeg", "image/jpeg"},
    {".jpg", "image/jpeg"},
    {".js", "application/javascript"},
    {".json", "application/json"},
    ...

## 備註

此版本與 [samuelneff](https://github.com/samuelneff/MimeTypeMap) 版本有些微的不同

在實際的經驗中，透過不同的瀏覽器上傳同樣的檔案，會產生不同的 mime，所以此套件將會回傳此副檔名所有符合的 mime

舉例來說：`.mp3` 和 `zip` 根據不同的瀏覽器都有不同的 mime, 參考: <https://stackoverflow.com/a/28021591/1799047> ；`.zip` 共有三種不同的 mime: `application/zip, application/octet-stream, application/x-zip-compressed`

## 貢獻

非常歡迎大家盡量提交 PR

## 安裝

在 NuGet 有提供套件可以安裝，或者是也可以自己把專案複製下來建置 dll.

```bash
Install-Package MimeTypeMap.List
```

## 支援平台

支援 .NET 4.5 以上與 .NET Core 1.0 以上

## 用法

### 安裝MimeTypeMap之後， 包括以下指令在您的class之中：

```csharp
using MimeTypeMap.List;
```

### 根據副檔名取得 mime

```csharp
Console.WriteLine("txt -> " + MimeTypeMap.GetMimeType("txt"));  // "text/plain"
```

如果沒有 mime 符合的話，預設會回傳 "application/octet-stream" 。

### 根據 mime 取得向對應的副檔名

```csharp
Console.WriteLine("audio/wav -> " + MimeTypeMap.GetExtension("audio/wav")); // ".wav"
```
