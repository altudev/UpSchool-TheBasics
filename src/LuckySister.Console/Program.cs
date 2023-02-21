using LuckySister.Console;
using UpSchool.Domain.Entities;

var selectionManager = new SelectionManager();

selectionManager.AddAttendee("Aleyna Meydan");
selectionManager.AddAttendee("Aslı Başaran");
selectionManager.AddAttendee("Aybike Boran");
selectionManager.AddAttendee("Ayça Akbaş");
selectionManager.AddAttendee("Ayfer Yıldırım");
selectionManager.AddAttendee("Ayşegül Aydın");
selectionManager.AddAttendee("Aysena Özcan");
selectionManager.AddAttendee("Ayşenur Taşkın");
selectionManager.AddAttendee("Betül Zilan Tüzün");
selectionManager.AddAttendee("Buket Soyhan");
selectionManager.AddAttendee("Çiğdem Çakır");
selectionManager.AddAttendee("Dilan Özer");
selectionManager.AddAttendee("Dilara Demirhan");
selectionManager.AddAttendee("Sema Topçu");
selectionManager.AddAttendee("Hanife Sayılır");
selectionManager.AddAttendee("Esin Yılmaz");
selectionManager.AddAttendee("Rana Kaya");
selectionManager.AddAttendee("Şevval Barın");
selectionManager.AddAttendee("Merve Şişeci");
selectionManager.AddAttendee("Serra Tuğ");
selectionManager.AddAttendee("Sibel Davun");
selectionManager.AddAttendee("Sümeyye Eraslan");
selectionManager.AddAttendee("Merve Albayrak");
selectionManager.AddAttendee("Tuğba Esat Şahin");
selectionManager.AddAttendee("Esen Kırca");
selectionManager.AddAttendee("Songül Bayer");
selectionManager.AddAttendee("Merve Bacak");
selectionManager.AddAttendee("Ezgi Oflar");
selectionManager.AddAttendee("Öznur Fidan");
selectionManager.AddAttendee("Saliha Apak");
selectionManager.AddAttendee("Sena Pekşin");
selectionManager.AddAttendee("Zeynep Hazneci");
selectionManager.AddAttendee("Ece Özçelik");
selectionManager.AddAttendee("Özlem Kalemci");

int luckyCount = 3;

selectionManager.MakeSelection(luckyCount);

var luckiestOnes = selectionManager.GetTheLuckyOnes();

luckiestOnes.ForEach(x => Console.WriteLine(x.FullName));

Console.ReadLine();





