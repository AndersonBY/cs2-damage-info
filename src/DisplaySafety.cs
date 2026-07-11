using System.Net;

namespace HybridDamageInfo;

public static class DisplaySafety
{
    public static string EncodeHtml(string value) => WebUtility.HtmlEncode(value);
}
