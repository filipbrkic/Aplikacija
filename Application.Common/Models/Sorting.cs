namespace Application.Common.Models
{
    public class Sorting
    {
        public Sorting(string sortOrder, string sortBy)
        {
            SortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;
            SortBy = sortBy;
        }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
    }
}
