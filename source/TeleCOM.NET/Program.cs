using TeleCOM.NET.Client;

KeyboardListener keyboardListener = new();
Task.Run(async() => await keyboardListener.StartRecievingAsync());
Console.ReadLine();

