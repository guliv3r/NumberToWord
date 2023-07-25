using Gulivera.NumberToWord;


decimal number = 94.00M;
var resp = Converter.Execute(number, "GEL", true);

Console.WriteLine(resp);
Console.ReadKey();

