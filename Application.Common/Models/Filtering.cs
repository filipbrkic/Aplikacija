namespace Application.Common.Models
{
    public class Filtering
    {
        public Filtering(string searchString)
        {
            SearchString = searchString;
        }

        public string SearchString { get; set; }
    }
}
