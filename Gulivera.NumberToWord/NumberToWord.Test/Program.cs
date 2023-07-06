using Gulivera.NumberToWord;


decimal number = 94.00M;
var resp = Converter.Execute(number, Converter.OptionType.GEL, true);

Console.WriteLine(resp);
Console.ReadKey();

