namespace Common.ViewModels
{
    public class PaginationViewModel
    {
        public int? PageIndex { get; set; } = 1;
        public int? PageLimit { get; set; } = 10;
    }
}
