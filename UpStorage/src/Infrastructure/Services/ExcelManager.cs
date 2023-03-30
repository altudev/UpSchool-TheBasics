using Application.Common.Interfaces;
using Application.Common.Models.Excel;
using ExcelMapper;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class ExcelManager:IExcelService
    {
        public List<ExcelCityDto> ReadCities(ExcelBase64Dto excelDto)
        {
            var fileBytes = Convert.FromBase64String(excelDto.File);

            using var stream = new MemoryStream(fileBytes);
            using var importer = new ExcelImporter(stream);

            ExcelSheet sheet = importer.ReadSheet();

            var cityDtos = sheet.ReadRows<ExcelCityDto>().ToList();


            return cityDtos;
        }
    }
}
