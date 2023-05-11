namespace UpSchool.Domain.Dtos
{
    public class SendLogNotificationApiDto
    {
        public SeleniumLogDto Log { get; set; }
        public string ConnectionId { get; set; }


        public SendLogNotificationApiDto(SeleniumLogDto log, string connectionId)
        {
            Log = log;

            ConnectionId = connectionId;
        }
    }
}
