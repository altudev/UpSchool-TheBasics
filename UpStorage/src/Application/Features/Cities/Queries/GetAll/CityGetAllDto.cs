namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsDeleted { get; set; }
    }
}
