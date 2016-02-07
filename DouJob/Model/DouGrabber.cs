using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouJob
{
    public static class DouGrabber
    {
        public static readonly string path = @"C:\DouStatistics\DouStatistics.txt";

        public static void Run(out string grabbResult)
        {
            List<JobType> JobTypes = new List<JobType>
            {
                new JobType(".NET", "http://jobs.dou.ua/vacancies/?city=Kyiv&category=.NET"),
                new JobType("Android", "http://jobs.dou.ua/vacancies/?city=Kyiv&category=Android"),
                new JobType("Python", "http://jobs.dou.ua/vacancies/?city=Kyiv&category=Python"),
                new JobType("Java", "http://jobs.dou.ua/vacancies/?city=Kyiv&category=Java")
            };

            FileWriter.WriteStringToFile(string.Format("--{0}--", DateTime.Now.ToString("dd.MM.yyyy")), path);
            grabbResult = string.Format("--{0}--{1}", DateTime.Now.ToString("dd.MM.yyyy"), Environment.NewLine);

            foreach (var jType in JobTypes)
            {
                string statsNumber = WebParser.ParseDouPage(jType.JobPageUrl);
                FileWriter.WriteStringToFile(string.Format("{0} {1}", jType.JobName, statsNumber), path);
                grabbResult += string.Format("{0} {1} {2}", jType.JobName, statsNumber, Environment.NewLine);
            }
        }

        public static bool IsFileModifiedToday()
        {
            var changeTimeUtc = File.GetLastWriteTimeUtc(path);
            if (DateTime.UtcNow.Subtract(changeTimeUtc).TotalHours < 24)
                return true;

            return false;
        }
    }
}
