namespace SM.Training.SharedComponent.Filter
{
    public class BaseFilter
    {
        public int PageIndex { get; set; }
        public string PageUrl { get; set; }
        public string OrderBy { get; set; }
        public bool IsExporting { get; set; }
        public string ReportDisplayName { get; set; }
    }
}
