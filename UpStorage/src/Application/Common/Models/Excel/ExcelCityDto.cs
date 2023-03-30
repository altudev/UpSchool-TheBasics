namespace Application.Common.Models.Excel
{
    public class ExcelCityDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
