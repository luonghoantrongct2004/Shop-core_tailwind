using System.Globalization;
using System.Text.RegularExpressions;

namespace Shop.Web.Utilities
{
    public class AppUtilities
    {
        public static bool IsValidEmail(string email)
        {
            if(string.IsNullOrEmpty(email)) return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMicroseconds(200));
                string DomainMapper(Match macth)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(macth.Groups[2].Value);
                    return macth.Groups[1].Value + domainName;
                }
            }
            catch
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
