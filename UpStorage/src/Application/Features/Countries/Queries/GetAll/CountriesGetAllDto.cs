namespace Application.Features.Countries.Queries.GetAll
{
    public class CountriesGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CountriesGetAllDto(int id, string name)
        {
            Id = id;

            Name = name;
        }
    }
}
