namespace Application.Dtos
{
    /// <summary>
    /// 分页请求Dto
    /// </summary>
    public class PagedRequestDto
    {
        public int PageSize { get; set; } = 10;

        public int PageIndex { get; set; } = 1;

        public string SqlWhere { get; set; }

        public string OrderBy { get; set; }

    }
}
