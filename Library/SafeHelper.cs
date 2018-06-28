using System.Text.RegularExpressions;

namespace Library
{
    public static class SafeHelper
    {
        /// <summary>过滤SQL和HTML敏感字符
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeSqlandHtml(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            str = Regex.Replace(str, @"<applet[^>]*?>.*?</applet>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<body[^>]*?>.*?</body>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<embed[^>]*?>.*?</embed>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frame[^>]*?>.*?</frame>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<frameset[^>]*?>.*?</frameset>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<html[^>]*?>.*?</html>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<style[^>]*?>.*?</style>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<layer[^>]*?>.*?</layer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<link[^>]*?>.*?</link>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<ilayer[^>]*?>.*?</ilayer>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<meta[^>]*?>.*?</meta>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<object[^>]*?>.*?</object>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"-->", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"<!--.*", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "eXeC", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "VaRcHaR", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "dEcLaRe", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "Char", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "chr", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "mid", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @";", string.Empty);
            str = Regex.Replace(str, @"'", string.Empty);
            str = Regex.Replace(str, @"&", string.Empty);
            str = Regex.Replace(str, @"%20", string.Empty);
            str = Regex.Replace(str, @"--", string.Empty);
            //str = Regex.Replace(str, @"==", string.Empty);
            str = Regex.Replace(str, @"<", string.Empty);
            str = Regex.Replace(str, @">", string.Empty);

            return str;
        }

        /// <summary>过滤SQL和HTML敏感字符
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSafeSql(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            str = Regex.Replace(str, "eXeC", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "VaRcHaR", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "dEcLaRe", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "Char", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "chr", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "mid", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @";", string.Empty);
            str = Regex.Replace(str, @"'", string.Empty);
            str = Regex.Replace(str, @"&", string.Empty);
            str = Regex.Replace(str, @"%20", string.Empty);
            str = Regex.Replace(str, @"--", string.Empty);
            //str = Regex.Replace(str, @"==", string.Empty);
            str = Regex.Replace(str, @"<", string.Empty);
            str = Regex.Replace(str, @">", string.Empty);

            return str;
        }
    }


}
