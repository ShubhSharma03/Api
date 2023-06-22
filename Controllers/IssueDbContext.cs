namespace trackingapi.Controllers
{
    public class modelIssueDbContext
    {
        public modelIssueDbContext(object issues)
        {
            Issues = issues;
        }

        public object Issues { get; internal set; }
    }
}