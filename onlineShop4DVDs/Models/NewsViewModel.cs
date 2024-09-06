using onlineShop4DVDs.Models;

public class NewsViewModel
{
    public IEnumerable<News> News { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalNewsCount { get; set; }

    public int TotalPages => (int)Math.Ceiling((double)TotalNewsCount / PageSize);
}