using MyApp.Enums;

namespace MyApp.DTOs.Common
{
    public class BaseQuery
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public string[] OrderBy { get; set; } = new[] { "CreatedOn" };
        public OrderingDirection Direction { get; set; } = OrderingDirection.Desc;
    }
    
}