using Domain.Common;
using MediatR;

namespace Application.Features.Excel.Commands.ReadCities
{
    public class ExcelReadCitiesCommand:IRequest<Response<int>>
    {
        public string ExcelBase64File { get; set; }
    }
}
