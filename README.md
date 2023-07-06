# NumberToWord
Numbers to words converter(Georgian)
რიცხვი სიტყვიერად - ქართულად!

 V 1.0.4 Added optional parametr print zero cents or not.

524
xutas ocdaotxi

19043
cxrameti atas ormocdasami

## Quick start

Installing package:
```powershell
Install-Package Gulivera.NumberToWord
```

```csharp
using Gulivera.NumberToWord;

var resp = Converter.Execute(123456, "GEL", true);

Console.WriteLine(resp);//ას ოცდასამი ათას ოთხას ორმოცდათექვსმეტი ლარი

```
