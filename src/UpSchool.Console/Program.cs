
using UpSchool.Console.Domain;
using UpSchool.Console.Enums;
using UpSchool.Console.FirstExample;

const string filePath = "c:\\users\\alper\\desktop\\Access_Control_Logs.txt"; // \

var logsText = File.ReadAllText(filePath);

// \n bir alt satıra geç demektir

var splitLines = logsText.Split('\n', StringSplitOptions.RemoveEmptyEntries);

var logs = new List<AccessControlLog>();

foreach (var line in splitLines.Skip(1))
{
    // " " => ""

    var logFields = line.Replace(" ",string.Empty)
        .Replace("\r", string.Empty)
        .Split("---", StringSplitOptions.RemoveEmptyEntries);

    var accessControlLog = new AccessControlLog()
    {
        UserId = Convert.ToInt32(logFields[0]),
        DeviceSerialNo = logFields[1],
        AccessType = AccessControlLog.ConvertToAccessType(logFields[2]),
        Date = Convert.ToDateTime(logFields[3])
    };

    logs.Add(accessControlLog);
}

var cardLogs = logs
    .Where(x => x.AccessType == AccessType.FACE)
    .Where(x=> x.DeviceSerialNo == "X01X2500S")
    .ToList();

// where1 && where 2 && where 3 && where n


cardLogs.ForEach(log => Console.WriteLine($"{log.UserId} - {log.DeviceSerialNo} - {log.AccessType} - {log.Date}"));

//foreach (var x in splitLines)
//{
//    Console.WriteLine(x);
//}

Console.ReadLine();

#region ReferenceExample

//int sayi1 = 15;

//Console.WriteLine(sayi1);

//int sayi2 = sayi1;

//sayi1 = 25;

//Console.WriteLine(sayi1);

//Console.WriteLine(sayi2);

//Student student1 = new Student();

//student1.FirstName = "Alper";
//student1.LastName = "Tunga";

//string name = "Maxwell";

//string surName = name;

//name = "Roberto Carlos";

//Student student2 = new Student(student1.FirstName,student1.LastName);

//student1.FirstName = student2.FirstName;

//student2.FirstName = "Tuba";

//Console.WriteLine(name);

//Console.WriteLine(surName);

//Console.ReadLine();

//var accessControlLog = new AccessControlLog();

//if (accessControlLog.AccessType == AccessType.FACE)
//{


//}

#endregion
