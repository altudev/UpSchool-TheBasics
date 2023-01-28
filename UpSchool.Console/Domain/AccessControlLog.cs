using UpSchool.Console.Enums;

namespace UpSchool.Console.Domain
{
    public class AccessControlLog
    {
        public int UserId { get; set; }
        public string DeviceSerialNo { get; set; }
        public AccessType AccessType { get; set; }
        public DateTimeOffset Date { get; set; }


        public static AccessType ConvertToAccessType(string accessType)
        {
            switch (accessType)
            {
                case "FACE": return AccessType.FACE;

                case "FP": return AccessType.FINGERPRINT;

                case "CARD": return AccessType.CARD;

                default:
                    throw new Exception("AccessType couldn't identified.");
            }

        }
    }
}
