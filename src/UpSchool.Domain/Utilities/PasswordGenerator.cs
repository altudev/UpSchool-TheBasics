using System.Text;
using UpSchool.Domain.Common;
using UpSchool.Domain.Dtos;

namespace UpSchool.Domain.Utilities
{
    public class PasswordGenerator
    {
        private const string Numbers = "0123456789";
        private const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SpecialCharacters = "!@#$%^&*()";

        private readonly Random _random;
        private readonly StringBuilder _passwordBuilder;
        private readonly StringBuilder _charSetBuilder;

        public PasswordGenerator()
        {
            _random = new Random();

            _passwordBuilder = new StringBuilder();

            _charSetBuilder = new StringBuilder();

        }

        public string Generate(GeneratePasswordDto generatePasswordDto)
        {
            _charSetBuilder.Clear();
            _passwordBuilder.Clear();

            if (generatePasswordDto.IncludeNumbers) _charSetBuilder.Append(Numbers);

            if (generatePasswordDto.IncludeLowercaseCharacters) _charSetBuilder.Append(LowercaseCharacters);

            if (generatePasswordDto.IncludeUppercaseCharacters) _charSetBuilder.Append(UppercaseCharacters);

            if (generatePasswordDto.IncludeSpecialCharacters) _charSetBuilder.Append(SpecialCharacters);

            //if (!generatePasswordDto.IncludeNumbers && !generatePasswordDto.IncludeLowercaseCharacters &&
            //!generatePasswordDto.IncludeUppercaseCharacters && !generatePasswordDto.IncludeSpecialCharacters
            //    )
            if(generatePasswordDto is
               {IncludeNumbers:false, IncludeLowercaseCharacters:false, 
                   IncludeUppercaseCharacters:false, IncludeSpecialCharacters:false})
            {
                return string.Empty;
            }

            var charSet = _charSetBuilder.ToString();

            for (int i = 0; i < generatePasswordDto.Length; i++)
            {
                var randomIndex = _random.Next(charSet.Length);

                _passwordBuilder.Append(charSet[randomIndex]);
            }

            return _passwordBuilder.ToString();
        }

    }
}
