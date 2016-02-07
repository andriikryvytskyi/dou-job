using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DouJob
{
    public class WebParser
    {
        public static async Task<string> ParseDouPageAsync(string pageUrl)
        {
            string statsNumber;
            using (var client = new WebClient())
            {
                client.Encoding = UTF8Encoding.UTF8;
                string result = client.DownloadString(pageUrl);
                string pattern = "b-inner-page-header\\\">[^<]+<h1>([0-9]+)";
                MatchCollection matches = Regex.Matches(result, pattern,
                                                        RegexOptions.IgnorePatternWhitespace);

                statsNumber = matches.Count > 0 ? matches[0].Groups[1].Value : "0";
            }

            return statsNumber;
        }

        public static string ParseDouPage(string pageUrl)
        {
            var task = ParseDouPageAsync(pageUrl);
            task.Wait();

            return task.Result;
        }
    }
}
