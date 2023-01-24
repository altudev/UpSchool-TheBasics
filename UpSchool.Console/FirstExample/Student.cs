namespace UpSchool.Console.FirstExample
{
    public class Student : PersonBase, ITurkishPerson, IAge
    {
        public int SchoolNumber { get; set; }
        public List<int> Scores { get; set; }
        public string TCID { get; set; }
        public string GovertmentId { get; set; } // SW-5528899
        public int Age { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(FirstName)) // Empty == ""
        //        {
        //            return "İsimsiz";
        //        }

        //        return $"{SchoolNumber} {FirstName} {LastName}";
        //    }
        //}

        public string FullName
        {
            get
            {
                return $"{SchoolNumber} {FirstName} {LastName}";
            }
            set
            {
                value = $"Şampiyon {FirstName} {LastName}";
            }
        }

        // Kötü kod yazıp, ileriyi düşünmediğimiz için patladık.
        // Bu yüzden bu kısım yorum satırı yapılmıştır.
        // Ancak; ilk derse ait bir hatıra olarakta saklanabilir. :)
        //public int FinalNotes => (Score1 + Score2 + Score3) / 3;


        private int TotalOfScores()
        {
            var totalScore = 0;
            foreach (var score in Scores)
            {
                totalScore += score;
            }

            return totalScore / Scores.Count;
        }

        public string GetFullName()
        {
            return $"{SchoolNumber} {FirstName} {LastName}";
        }
    }
}
