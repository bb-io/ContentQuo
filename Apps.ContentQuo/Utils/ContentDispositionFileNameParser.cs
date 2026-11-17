using System.Net.Http.Headers;
using System.Text;

namespace Apps.ContentQuo.Utils;

internal static class ContentDispositionFileNameParser
{
    public static string GetFileName(string? contentDisposition, string fallbackFileName)
    {
        var fileName = TryParseFileName(contentDisposition)
            ?? TryExtractMalformedFileName(contentDisposition);

        return SanitizeFileName(fileName, fallbackFileName);
    }

    private static string? TryParseFileName(string? contentDisposition)
    {
        if (string.IsNullOrWhiteSpace(contentDisposition) ||
            !ContentDispositionHeaderValue.TryParse(contentDisposition, out var parsedContentDisposition))
        {
            return null;
        }

        return parsedContentDisposition.FileNameStar ?? parsedContentDisposition.FileName;
    }

    private static string? TryExtractMalformedFileName(string? contentDisposition)
    {
        if (string.IsNullOrWhiteSpace(contentDisposition))
        {
            return null;
        }

        var encodedFileName = ExtractParameterValue(contentDisposition, "filename*");
        if (!string.IsNullOrWhiteSpace(encodedFileName))
        {
            var encodingSeparatorIndex = encodedFileName.IndexOf("''", StringComparison.Ordinal);
            var encodedValue = encodingSeparatorIndex >= 0
                ? encodedFileName[(encodingSeparatorIndex + 2)..]
                : encodedFileName;

            try
            {
                return Uri.UnescapeDataString(encodedValue);
            }
            catch (UriFormatException)
            {
                // Continue with the regular filename parameter or the configured fallback.
            }
        }

        return ExtractParameterValue(contentDisposition, "filename");
    }

    private static string? ExtractParameterValue(string headerValue, string parameterName)
    {
        var parameterStart = headerValue.IndexOf(
            $"{parameterName}=",
            StringComparison.OrdinalIgnoreCase);

        if (parameterStart < 0)
        {
            return null;
        }

        var valueStart = parameterStart + parameterName.Length + 1;
        if (valueStart >= headerValue.Length)
        {
            return null;
        }

        var value = headerValue[valueStart..].TrimStart();
        if (value.Length == 0)
        {
            return null;
        }

        if (value[0] == '"')
        {
            var closingQuote = value.IndexOf('"', 1);
            return closingQuote > 0 ? value[1..closingQuote] : value[1..];
        }

        var nextParameter = value.IndexOf(';');
        return (nextParameter >= 0 ? value[..nextParameter] : value).Trim();
    }

    private static string SanitizeFileName(string? fileName, string fallbackFileName)
    {
        var sanitizedFileName = Sanitize(fileName);
        if (!string.IsNullOrWhiteSpace(sanitizedFileName))
        {
            return sanitizedFileName;
        }

        var sanitizedFallback = Sanitize(fallbackFileName);
        return string.IsNullOrWhiteSpace(sanitizedFallback) ? "downloaded-file" : sanitizedFallback;
    }

    private static string? Sanitize(string? fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return null;
        }

        var normalizedFileName = fileName.Trim().Trim('"').Replace('\\', '/');
        normalizedFileName = normalizedFileName[(normalizedFileName.LastIndexOf('/') + 1)..];

        var result = new StringBuilder(normalizedFileName.Length);
        foreach (var character in normalizedFileName)
        {
            if (!char.IsControl(character))
            {
                result.Append(character);
            }
        }

        return result.ToString().Trim();
    }
}
