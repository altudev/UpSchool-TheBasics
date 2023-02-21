namespace UpSchool.Domain.Dtos
{
    public class GeneratePasswordDto
    {
        public bool IncludeNumbers { get; set; }
        public bool IncludeLowercaseCharacters { get; set; }
        public bool IncludeUppercaseCharacters { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        public int Length { get; set; }

        public GeneratePasswordDto()
        {
            IncludeNumbers = true;

            IncludeLowercaseCharacters = true;

            Length = 25;
        }
    }
}
