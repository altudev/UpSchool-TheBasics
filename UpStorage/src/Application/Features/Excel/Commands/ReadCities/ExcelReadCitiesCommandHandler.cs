using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Excel.Commands.ReadCities
{
    public class ExcelReadCitiesCommandHandler:IRequestHandler<ExcelReadCitiesCommand,object>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IExcelService _excelService;

        public ExcelReadCitiesCommandHandler(IApplicationDbContext applicationDbContext, IExcelService excelService)
        {
            _applicationDbContext = applicationDbContext;
            _excelService = excelService;
        }

        public Task<object> Handle(ExcelReadCitiesCommand request, CancellationToken cancellationToken)
        {
            //var cityDtos = _excelService.ReadCities(request.ExcelBase64File);

            //_applicationDbContext.Cities.Add();

            return new Task<object>(() => true);
        }
    }
}
