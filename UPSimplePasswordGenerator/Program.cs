using UPSimplePasswordGenerator;

var passwordGenerator = new PasswordGenerator();

passwordGenerator.Greetings();

passwordGenerator.ReadInputs();

passwordGenerator.Generate();

passwordGenerator.WriteLatestGeneratedPassword();

Console.ReadLine();

return 0;
