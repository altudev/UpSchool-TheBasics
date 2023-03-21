using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSchool.Domain.Entities;

namespace UpSchool.Persistence.EntityFramework.Seeders
{
    public class AccountSeeder:IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(GetInitialAccounts());
        }

        private List<Account> GetInitialAccounts()
        {
            return new List<Account>()
            {
                new Account()
                {
                    Id = new Guid("a122163c-b2bc-4068-93de-58c8a1122d88"),
                    Title = "Google",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T17:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("93462dcf-f009-458c-9dce-c813ac2de2ca"),
                    Title = "Facebook",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T18:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("30d43e66-a177-4d6d-9644-5b9425a83aaf"),
                    Title = "Tiktok",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T19:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("38576d84-cef2-4285-b8aa-a375f6bce7c3"),
                    Title = "Instagram",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T20:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("fa588f1f-b4b0-4330-978c-bd0da99a6567"),
                    Title = "Twitter",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T21:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("c4d97d5c-4309-4acc-b4b3-078ceffcea4c"),
                    Title = "Trendyol",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T22:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("24af79f6-d586-419e-a684-143de39098e1"),
                    Title = "Udemy",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T23:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("6320cdfc-6e37-4f7b-b8af-0d8c60922994"),
                    Title = "Getir",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T00:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("c6c5378a-b759-4034-984f-7ec58628c3f7"),
                    Title = "Hepsiburada",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T01:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                },
                new Account()
                {
                    Id = new Guid("c2b18a4f-7d5e-4696-932b-6797b7f4d661"),
                    Title = "Coursera",
                    IsFavourite = true,
                    CreatedOn = Convert.ToDateTime("2023-03-21T02:43:17+00:00"),
                    UserName = "upschool",
                    Password = "MTIzdXBzY2hvb2wxMjM=",
                    Url = String.Empty,
                }
            };
        }
    }
}
