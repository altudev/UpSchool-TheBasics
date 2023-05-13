using UpSchool.Domain.Dtos;
using UpSchool.Domain.Utilities;

namespace UpSchool.Domain.Tests.Utilities
{
    public class PasswordGeneratorTests
    {

        [Fact]
        public void Generate_ShouldReturnEmptyString_WhenNoCharactersAreIncluded()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeNumbers = false,
                IncludeLowercaseCharacters = false,
                IncludeUppercaseCharacters = false,
                IncludeSpecialCharacters = false
            };

            // Act
            var password = passwordGenerator.Generate(generatePasswordDto);

            // Assert
            Assert.Equal(string.Empty, password);
        }

        [Fact]
        public void Generate_ShouldReturnPasswordWithGivenLength()
        {
            var passwordGenerator = new PasswordGenerator();

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeLowercaseCharacters = true,
                IncludeNumbers = true,
                IncludeSpecialCharacters = true,
                IncludeUppercaseCharacters = true,
            };

            // Act
            var password = passwordGenerator.Generate(generatePasswordDto);

            //Assert
            Assert.Equal(generatePasswordDto.Length, password.Length);

        }

        [Fact]
        public void Generate_ShouldIncludeNumbers_WhenIncludeNumbersIsTrue()
        {
            var passwordGenerator = new PasswordGenerator(); 
            
            var generatePasswordDto = new GeneratePasswordDto() 
                { 
                    Length = 20, IncludeNumbers = true, 
                    IncludeLowercaseCharacters = false, 
                    IncludeSpecialCharacters = false, 
                    IncludeUppercaseCharacters = false
                }; 
            
            var password = passwordGenerator.Generate(generatePasswordDto); 
            
            
            Assert.Contains(password, x => char.IsDigit(x));
        }


    }
}
