using Domain.Entities;

namespace Application.Common.Models.Excel
{
    public class ExcelCityDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }


        public City MapToCity()
        {
            return new City()
            {
                Id = this.Id,
                CountryId = this.CountryId,
                Name = this.Name,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
                IsDeleted = false,
            };
        }
    }
}
