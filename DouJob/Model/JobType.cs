namespace DouJob
{
    public class JobType
    {
        public string JobName { get; set; }
        public string JobPageUrl { get; set; }

        public JobType(string jobName, string jobPageUrl)
        {
            JobName = jobName;
            JobPageUrl = jobPageUrl;
        }
    }
}
