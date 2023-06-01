// See https://aka.ms/new-console-template for more information
using Homework1_Nataliia;

Console.WriteLine("Hello, World!");

Person person = new Person();
Person person2 = new Person();
Person person3 = new Person();
Person person4 = new Person();

person. LN= "fdg";
Console.WriteLine($"{person.LN}");
person2.LN = "fdgghggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
Console.WriteLine($"{person2.LN}");
person3.LN = "";
Console.WriteLine($"{person3.LN}");
person4.LN = "Папуга";
Console.WriteLine($"{person4.LN}");


person.FN = "fdg";
Console.WriteLine($"{person.FN}");
person2.FN = "fdgghggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
Console.WriteLine($"{person2.FN}");
person3.FN = "";
Console.WriteLine($"{person3.FN}");
person4.FN = "Білка";
Console.WriteLine($"{person4.FN}");

person.DOB = new DateTime(2022, 01, 01);
Console.WriteLine($" good time {person.DOB}");
person2.DOB = new DateTime(2024, 01, 01);
Console.WriteLine($" good time {person2.DOB}");

person.INN = "YU8434567898";
Console.WriteLine($"CORRECT {person.INN}");
person2.INN = "YUU843456789822";
Console.WriteLine($" INCORRECT {person2.INN}");