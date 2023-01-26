using LuckySister.Console;
using UpSchool.Domain.Entities;

var selectionManager = new SelectionManager();

selectionManager.AddAttendee("Ayfer Yıldırım");
selectionManager.AddAttendee("Aybike Boran");
selectionManager.AddAttendee("Öznur Fidan");
selectionManager.AddAttendee("Merve Albayrak");
selectionManager.AddAttendee("Dilara Demirhan");

int luckyCount = 6;

selectionManager.MakeSelection(luckyCount);

var luckiestOnes = selectionManager.GetTheLuckyOnes();

luckiestOnes.ForEach(x => Console.WriteLine(x.FullName));

Console.ReadLine();





