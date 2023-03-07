using Gulivera.NumberToWord;


decimal number = 1234.50M;
var resp = Converter.Execute(number, Converter.OptionType.GEL);

Console.WriteLine(resp);
Console.ReadKey();

