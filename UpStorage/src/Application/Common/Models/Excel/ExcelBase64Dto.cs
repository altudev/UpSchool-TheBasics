namespace Application.Common.Models.Excel
{
    public class ExcelBase64Dto
    {
        public string File { get; set; }

        public ExcelBase64Dto()
        {
            
        }

        public ExcelBase64Dto(string file)
        {
            File =file;
        }
    }
}
