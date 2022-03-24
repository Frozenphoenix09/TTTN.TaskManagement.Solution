namespace TTTN.TaskManagement.Data.SeedWork
{
    public class PagingParameters
    {
        private const int maxPageSize = 50;
        public int CurrentPage { get; set; } = 1;
        private int _pageSize = 4;

        public int PageSize
        {
            get { return _pageSize; }

            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}