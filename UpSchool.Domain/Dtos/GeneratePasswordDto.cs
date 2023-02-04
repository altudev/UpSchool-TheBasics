namespace UpSchool.Domain.Dtos
{
    public class GeneratePasswordDto
    {
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeLowercaseCharacters { get; set; } = true;
        public bool IncludeUppercaseCharacters { get; set; }
        public bool IncludeSpecialCharacters { get; set; }
        public int Length { get; set; } = 6;
    }
}
