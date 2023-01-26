using UpSchool.Domain.Entities;

namespace LuckySister.Console
{
    public class SelectionManager
    {
        private List<Attendee> Attendees { get; set; }
        // /* SelectedAttendees = SelectedAttendees */
        private List<Attendee> SelectedAttendees { get; set; }

        private Random _random;

        public SelectionManager(List<Attendee> initialAttendees)
        {
            Attendees = new List<Attendee>();

            Attendees.AddRange(initialAttendees);

            SelectedAttendees = new List<Attendee>();

            _random = new Random();
        }

        public SelectionManager()
        {
            Attendees = new List<Attendee>();

            SelectedAttendees = new List<Attendee>();

            _random = new Random();
        }


        public void MakeSelection(int luckyCount)
        {
            if (luckyCount>Attendees.Count)
            {
                throw new Exception("LuckyCount cannot be more then the attendees count.");
            }

            for (int i = 0; i < luckyCount; i++)
            {
                SelectedAttendees.Add(GetRandomAttendee());
            }
        }

        public List<Attendee> GetTheLuckyOnes()
        {
            return SelectedAttendees;
        }

        private Attendee GetRandomAttendee()
        {
            var randomIndex = _random.Next(Attendees.Count);

            var attendee = Attendees[randomIndex];

            return SelectedAttendees.Any(x => x.Id == attendee.Id) ? GetRandomAttendee() : attendee;
        }

        //if (SelectedAttendees.Any(x => x.Id == attendee.Id))
        //{
        //    return GetRandomAttendee();
        //}


        public void AddAttendee(Attendee attendee)
        {
            Attendees.Add(attendee);
        }

        public void AddAttendee(string fullName)
        {
            Attendee attendee = new Attendee()
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                CreatedOn = DateTimeOffset.Now
            };

            Attendees.Add(attendee);
        }

        public int GetAttendeesCount()
        {
            return Attendees.Count;
        }
    }
}
